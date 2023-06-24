using MvcCoreCv.Entities;
using MvcCoreCv.Models;
using MvcCoreCv.Repositories.Abstract;

namespace MvcCoreCv.Repositories.Concrete
{
    public class AboutRepository : GenericRepository<TblAbout>, IAboutRepository
    {
        //private readonly AppDbContext _context;
        public AboutRepository(AppDbContext context) : base(context)
        {
            //_context = context;
        }
        //Buraya özel metotlar yazarken yorum satırlarını aktif hale getirir kullanırım


    }
}
