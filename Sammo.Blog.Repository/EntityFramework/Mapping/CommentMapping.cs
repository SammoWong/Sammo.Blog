using Sammo.Blog.Domain.Constants;
using Sammo.Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sammo.Blog.Repository.EntityFramework.Mapping
{
    class CommentMapping : EntityTypeConfiguration<Comment>
    {
        public CommentMapping()
        {
            ToTable("Comment");

            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("Id").IsRequired();
            Property(c => c.Content).HasColumnName("Content").IsRequired().HasMaxLength(SammoConstants.Validation.CommentMaxLength);
            Property(c => c.CreatedOn).HasColumnName("CreatedOn").IsRequired();
        }
    }
}
