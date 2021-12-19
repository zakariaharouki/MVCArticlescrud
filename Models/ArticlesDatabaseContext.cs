using Microsoft.EntityFrameworkCore;
using MVCArticlescrud.Models;
namespace MVCArticlescrud.Models
{
    public class ArticlesDatabaseContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer(@"data source=MSI;Initial Catalog=Task;Integrated Security=True");
        }
    }
}
