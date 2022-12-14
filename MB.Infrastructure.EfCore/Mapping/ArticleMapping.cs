using MB.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MB.Infrastructure.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired();
            builder.Property(x => x.ShortDescription);
            builder.Property(x => x.Image);
            builder.Property(x => x.Content);
            builder.Property(x => x.IsDeleted);
            builder.Property(x => x.CreationDate);

            builder.HasOne(x=>x.ArticleCategory).WithMany(x=>x.articles).HasForeignKey(x=>x.ArticleCategoryId);

        }
    }
}
