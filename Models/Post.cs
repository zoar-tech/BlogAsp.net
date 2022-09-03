namespace NewApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PostBody { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}