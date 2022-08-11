using Microsoft.EntityFrameworkCore;
using ASP_MVC_Test.Models;

namespace ASP_MVC_Test.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options) { }

        public DbSet<BookViewModel> PhoneNotes { get; set; }
    }
}
