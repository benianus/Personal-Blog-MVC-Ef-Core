using System.Diagnostics.CodeAnalysis;

namespace PersonalBlog.Models
{
    public class ArticleModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        [AllowNull]
        public string PublishDate { get; set; }

    }
}
