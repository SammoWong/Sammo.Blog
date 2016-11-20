namespace Sammo.Blog.Domain.Entities
{
    public class ArticleTag : EntityBase
    {
        public virtual Article Article { get; set; }

        public virtual Tag Tag { get; set; }
    }
}
