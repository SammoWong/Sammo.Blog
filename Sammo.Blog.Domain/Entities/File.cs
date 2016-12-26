using System;

namespace Sammo.Blog.Domain.Entities
{
    public class File : EntityBase
    {
        public string FileUrl { get; set; }

        public short Type { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
