using Sammo.Blog.Domain.Constants;
using Sammo.Blog.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Sammo.Blog.Repository.EntityFramework.Mapping
{
    public class CategoryMapping:EntityTypeConfiguration<Category>
    {
        public CategoryMapping()
        {
            //Table
            ToTable("Category");

            //Key
            HasKey(c => c.Id);

            //Properties
            Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(SammoConstants.Validation.CategoryNameMaxLength);
            Property(c => c.Description).HasColumnName("Description").IsOptional().HasMaxLength(SammoConstants.Validation.CagegoryDescriptionMaxLength);
            Property(c => c.CreatedTime).HasColumnName("CreatedTime").IsRequired();
            Property(c => c.LastEditTime).HasColumnName("LastEditTime").IsOptional();

            //Relationships
            HasMany(c => c.Articles).WithOptional(c => c.Category).Map(c => c.MapKey("CatogotyId")).WillCascadeOnDelete(false);
        }

    }
}
