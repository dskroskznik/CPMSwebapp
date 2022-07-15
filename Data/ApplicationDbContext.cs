using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CPMSwebapp.Models;

namespace CPMSwebapp.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CPMSwebapp.Models.Author>? Author { get; set; }
        public virtual DbSet<CPMSwebapp.Models.Paper>? Paper { get; set; }
        public virtual DbSet<CPMSwebapp.Models.Review>? Review { get; set; }
        public virtual DbSet<CPMSwebapp.Models.Reviewer>? Reviewer { get; set; }

    }
}

