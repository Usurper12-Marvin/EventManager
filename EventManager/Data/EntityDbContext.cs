using EventManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace EventManager.Data
{
    public class EntityDbContext : DbContext
    {
        public EntityDbContext(DbContextOptions<EntityDbContext> options) : base (options)
        {
            
        }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Attendee>().ToTable("Attendee");
            modelBuilder.Entity<Event>().ToTable("Event");
        }
    }
}
