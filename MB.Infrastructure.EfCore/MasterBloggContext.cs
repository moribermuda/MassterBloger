using MB.Domain.ArticleAgg;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.EfCore
{
    public class MasterBloggContext : DbContext
    {
        public DbSet<Article> articles { get; set; }
        public DbSet<Comment> commnts { get; set; }
        public DbSet<ArticleCategory> articleCategories { get; set; }
        public MasterBloggContext(DbContextOptions<MasterBloggContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembley = typeof(ArticleMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembley);
            //modelBuilder.ApplyConfiguration(new CommentMapping());
            //modelBuilder.ApplyConfiguration(new ArticleMapping());
            //modelBuilder.ApplyConfiguration(new ArticleCategoryMapping());
            base.OnModelCreating(modelBuilder);
        }



    }
}