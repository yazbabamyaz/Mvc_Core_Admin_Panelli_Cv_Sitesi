using MvcCoreCv.Entities;

namespace MvcCoreCv.Repositories.Abstract
{
    public interface IAwardRepository:IRepository<TblAward>
    {
        //IRepository den gelen ortak metotlar burada gibi düşün.
        //Ve Award a özel metotlar buraya yazılır varsa.
    }
}
