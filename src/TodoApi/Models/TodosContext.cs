using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodosContext : DbContext
    {
        public TodosContext(DbContextOptions options)
             : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }
    }
}
