using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace MvcCoreCv.Entities
{
    public class TblEducation : BaseEntity
    {
        public int Id { get; set; }        
        public string Title { get; set; }       
        public string SubTitle1 { get; set; }
        public string SubTitle2 { get; set;}
        public string GPA { get; set;}
        public string Date { get; set; }
    }
}
