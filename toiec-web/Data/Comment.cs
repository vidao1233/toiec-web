namespace toiec_web.Models
{
    public class Comment
    {
        public Guid idComment { get; set; }
        public string idUser { get; set; }
        public Guid idPost { get; set; }
        public string content { get; set; }
        public DateTime createdDate { get; set; }
        public virtual Users Users { get; set; }
        public virtual Post Post { get; set; }
    }
}
