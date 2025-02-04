namespace PersonalBlog.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public int PersonModelId { get; set; }
        public List<ArticleModel> Articles { get; set; } = new List<ArticleModel>();  
    }
}
