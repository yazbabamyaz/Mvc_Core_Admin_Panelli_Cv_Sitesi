namespace MvcCoreCv.Entities
{
    public class TblContact : BaseEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Mail { get; set; }
        public string Subject { get; set; }
        public DateTime  Date { get; set; }
        public string Message { get; set; }
    }
}
