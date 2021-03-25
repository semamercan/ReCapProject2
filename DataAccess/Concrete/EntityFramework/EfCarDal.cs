using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentCarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using(RentCarContext context=new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 ModelYear = c.ModelYear,
                                 Status = !context.Rentals.Any(r => r.CarId == c.CarId && r.ReturnDate == null),
                                 ImagePath = (from a in context.CarImages where a.CarId == c.CarId select a.ImagePath).FirstOrDefault()

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList(); //Boş işe değeri döndürür. Boş değil işe filtere göre değeri döndürüp liste dönüştürür.
            }
        }

        public CarDetailDto GetCarDetails(int carId)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join co in context.Colors on c.ColorId equals co.ColorId

                             select new CarDetailDto
                             {
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 ColorName = co.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description,
                                 BrandId = b.BrandId,
                                 ColorId = co.ColorId,
                                 ModelYear = c.ModelYear,
                                 Status = !context.Rentals.Any(r => r.CarId == c.CarId && r.ReturnDate == null),
                              
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
