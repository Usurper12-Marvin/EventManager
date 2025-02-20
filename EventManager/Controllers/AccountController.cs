using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static EventManager.Models.ViewModels.UserViewModels;

namespace EventManager.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private RoleManager<IdentityRole> roleManager;
        private readonly string _role = "Attendee";
        public AccountController(UserManager<IdentityUser> userManager,
        SignInManager<IdentityUser> signInManager,
        RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                if (await roleManager.FindByNameAsync(_role) == null)
                {
                    await roleManager.CreateAsync(new IdentityRole(_role));
                }

                var user = new IdentityUser
                {
                    UserName = registerModel.Username,
                    Email = registerModel.Email
                };

                var result = await _userManager.CreateAsync(user, registerModel.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, _role);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Unable to register new user");
                }
            }
            return View(registerModel);
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                await _userManager.FindByNameAsync(loginModel.UserName);

                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,
                      loginModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Event/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid username or password");
            return View(loginModel);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Event");
        }
    }
}
