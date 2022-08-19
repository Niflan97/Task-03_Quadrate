using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Data
{
    public class WebApplication4DbContext: DbContext
    {
        public WebApplication4DbContext(DbContextOptions options, DbSet<Contacts> contacts) : base(options)
        {
            
        }
        public  DbSet<Contacts> Contacts { get; set; }
    }
}

