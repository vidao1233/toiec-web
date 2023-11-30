namespace toiec_web.Models
{
    public class Post
    {
        public Guid idPost { get; set; }
        public string idUser { get; set; }
        public string title { get; set; }
        public DateTime createdTime { get; set; }
        public virtual Users Users { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Report> Reports { get; set; }
    }
}
