using MB.Domain.ArticleCategoryAgg;
using MB.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore
{
    public class MasterBloggContext : DbContext
    {
        public DbSet<ArticleCategory> articleCategories { get; set; }
        public MasterBloggContext(DbContextOptions<MasterBloggContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }



    }
}