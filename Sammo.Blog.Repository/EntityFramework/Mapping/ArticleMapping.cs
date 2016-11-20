using Sammo.Blog.Domain.Constants;
using Sammo.Blog.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sammo.Blog.Repository.EntityFramework.Mapping
{
    public class ArticleMapping : EntityTypeConfiguration<Article>
    {
        public ArticleMapping()
        {
            //Table
            ToTable("Article");

            //Key
            HasKey(a => a.Id);

            // Properties
            Property(a => a.Id).HasColumnName("Id").IsRequired();
            Property(a => a.Title).HasColumnName("Title").IsRequired().HasMaxLength(SammoConstants.Validation.ArticleTitleMaxLength);
            Property(a => a.Content).HasColumnName("Content").IsRequired();
            Property(a => a.IsTop).HasColumnName("IsTop").IsRequired();
            Property(a => a.PageViews).HasColumnName("PageViews").IsOptional();
            Property(a => a.CreatedTime).HasColumnName("CreatedTime").IsRequired();
            Property(a => a.LastEditTime).HasColumnName("LastEditTime").IsOptional();

        }
    }
}
