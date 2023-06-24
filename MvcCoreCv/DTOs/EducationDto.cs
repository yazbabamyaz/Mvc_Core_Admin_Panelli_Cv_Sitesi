using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;
namespace MvcCoreCv.DTOs
{
    public class EducationDto
    {
        public int Id { get; set; }        
        public string Title { get; set; }        
        public string SubTitle1 { get; set; }       
        public string SubTitle2 { get; set; }        
        public string GPA { get; set; }        
        public string Date { get; set; }
    }
}
