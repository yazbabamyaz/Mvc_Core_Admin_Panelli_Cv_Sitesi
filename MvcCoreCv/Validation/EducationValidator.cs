using FluentValidation;
using MvcCoreCv.DTOs;

namespace MvcCoreCv.Validation
{
    public class EducationValidator:AbstractValidator<EducationDto>
    {
        //AbstractValidator dan türemesi gerekir.Program.cs deki fonksiyonumuz uygulamada-BU assembly içerisinde- AbstractValidator dan türeyen sınıfların bir validator sınıfı olduğunu anlayacak ve validasyonları ise constructor ile tanımlayacağız.
        public EducationValidator()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage("Boş geçemezsin.")
                .NotEmpty().WithMessage("Boş geçemezsin.")
                .Length(5,50).WithMessage("karaktere dikkat.");
            
            RuleFor(x => x.Date).NotNull().NotEmpty().WithMessage("Tarih bilgisini Boş Geçemezsin...");

            RuleFor(x => x.SubTitle1).NotNull().WithMessage("Boş geçemezsin.").NotEmpty().WithMessage("Boş geçemezsin.");

            RuleFor(x => x.SubTitle2).NotNull().WithMessage("Boş geçemezsin.").NotEmpty().WithMessage("Boş geçemezsin.");

            RuleFor(x => x.GPA)
                .NotNull().WithMessage("Ortalama Boş geçemezsin.")
                .NotEmpty().WithMessage(" Ortalama Boş geçemezsin.")
                .MaximumLength(5).WithMessage("Ortalama 5'i geçemez.");


        }
    }
}
