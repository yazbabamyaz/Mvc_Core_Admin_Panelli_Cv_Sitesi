namespace MvcCoreCv.Entities
{
    public class TblAdmin : BaseEntity
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
