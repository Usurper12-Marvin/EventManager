using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Data
{
    public class IdentityDbContext(DbContextOptions dbContext) : IdentityDbContext<IdentityUser>(dbContext)
    {
    }
}
