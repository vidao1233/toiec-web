namespace toeic_web.Models
{
    public class Report
    {
        public Guid idReport {  get; set; }
        public string idUser { get; set; }
        public Guid idAdmin { get; set; }
        public Guid idPost { get; set; }
        public string reason { get; set; }
        public bool isCheck { get; set; }
        public DateTime reportDate { get; set; }
        public virtual Users Users { get; set; }
        public virtual Admin Admin { get; set; }
        public virtual Post Post { get; set; }
    }
}
