using Quiz_Zone.Models;
using System.Data.Entity;

namespace Quiz_Zone.Repository
{
    public class EFDbContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
    }
}