using Microsoft.EntityFrameworkCore;
using WebContact.Models;

namespace WebContact.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<ContactViewModel> Contact { get; set; }
    }
}
