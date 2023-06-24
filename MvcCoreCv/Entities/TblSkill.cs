namespace MvcCoreCv.Entities
{
    public class TblSkill : BaseEntity
    {
        public int Id { get; set; }
        public string Skills { get; set; }
        public byte Percent { get; set; }
    }
}
