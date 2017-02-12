using Sammo.Blog.Domain.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace Sammo.Blog.Application.Blog.Dto
{
    public class AddBlogInput
    {
        [Required, MaxLength(SammoConstants.Validation.ArticleTitleMaxLength
            , ErrorMessage = SammoConstants.Error.ArticleTitleLengthError)]
        public string Title { get; set; }

        [Required]
        public string Article { get; set; }

        public string TagNameString { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required, Display(Name = "是否置顶？")]
        public bool IsTop { get; set; }
    }
}
