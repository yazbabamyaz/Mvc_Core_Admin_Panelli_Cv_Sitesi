using Microsoft.EntityFrameworkCore;
using MvcCoreCv.Entities;

namespace MvcCoreCv.Models
{
    public class AppDbContext:DbContext
    {        
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        { 

        }
        public DbSet<TblAbout> TblAbouts { get; set; }
        public DbSet<TblAdmin> TblAdmins { get; set; }
        public DbSet<TblAward> TblAwards { get; set;}
        public DbSet<TblEducation> TblEducations { get;set; }
        public DbSet<TblExperince> TblExperiences { get;set; }
        public DbSet<TblHobby> TblHobbies { get;set; }
        public DbSet<TblContact> TblContacts { get; set;}
        public DbSet<TblSkill> TblSkills { get; set; }
        public DbSet<TblSocial> TblSocials { get; set; }
        
    }
}
