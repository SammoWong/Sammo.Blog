﻿using System.Data.Entity.ModelConfiguration;
using Sammo.Blog.Domain.Constants;

namespace Sammo.Blog.Repository.EntityFramework.Mapping
{
    public class BlogMapping: EntityTypeConfiguration<Domain.Entities.Blog>
    {
        public BlogMapping()
        {
            //Table
            ToTable("Blog");

            //Key
            HasKey(b => b.Id);

            //Properties
            Property(b => b.Id).HasColumnName("Id").IsRequired();
            Property(b => b.Name).HasColumnName("Name").IsRequired().HasMaxLength(SammoConstants.Validation.BlogNameMaxLength);
            Property(b => b.Description).HasColumnName("Description").IsOptional().HasMaxLength(SammoConstants.Validation.BlogDescriptionMaxLength);
            Property(b => b.Url).HasColumnName("Url").IsOptional().HasMaxLength(SammoConstants.Validation.UrlMaxLength);
            Property(b => b.Visits).HasColumnName("Visits").IsRequired();
            Property(b => b.PageViews).HasColumnName("PageViews").IsRequired();
            Property(b => b.IsEnabled).HasColumnName("IsEnabled").IsRequired();
            Property(b => b.CreatedOn).HasColumnName("CreatedOn").IsRequired();
            Property(b => b.ModifiedOn).HasColumnName("ModifiedOn").IsOptional();

            //Relationships
            HasMany(b => b.Tags).WithRequired(b => b.Blog).Map(b => b.MapKey("BlogId")).WillCascadeOnDelete(false);
            HasMany(b => b.Articles).WithRequired(b => b.Blog).Map(b => b.MapKey("BlogId")).WillCascadeOnDelete(false);
        }
    }
}
