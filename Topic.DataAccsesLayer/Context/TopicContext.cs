

using Microsoft.EntityFrameworkCore;
using Topic.EntityLayer.Entities;

namespace Topic.DataAccsesLayer.Context
{
    public class TopicContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = DESKTOP-TOGRPIE\\SQLEXPRESS; database=MyAcademyTopicDb; integrated security = true; trustServerCertificate=true");
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Manuel> Manuels { get; set; }
    }
}
