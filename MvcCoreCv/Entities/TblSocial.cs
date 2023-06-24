namespace MvcCoreCv.Entities
{
    public class TblSocial:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public bool Status { get; set; }

    }
}
