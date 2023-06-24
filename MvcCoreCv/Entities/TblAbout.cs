namespace MvcCoreCv.Entities
{
    public class TblAbout:BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Mail { get; set; }
    }
}
