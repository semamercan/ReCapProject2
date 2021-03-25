using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.UserId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join u in context.Users on cu.UserId equals u.Id
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = c.CarId,
                                 BrandName=b.BrandName,
                                 DailyPrice=c.DailyPrice,
                                 ColorName=co.ColorName,
                                 CompanyName = cu.CompanyName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 UserName = u.FirstName + " " + u.FirstName,
                                 RentDate = (DateTime)r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public RentalDetailDto GetRentalDetails(int id)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.CarId
                             join cu in context.Customers on r.CustomerId equals cu.UserId
                             join b in context.Brands on c.BrandId equals b.BrandId
                             join u in context.Users on cu.UserId equals u.Id
                             join co in context.Colors on c.ColorId equals co.ColorId
                             select new RentalDetailDto
                             {
                                 Id = r.Id,
                                 CarId = c.CarId,
                                 BrandName = b.BrandName,
                                 DailyPrice = c.DailyPrice,
                                 ColorName = co.ColorName,
                                 CompanyName = cu.CompanyName,
                                 Description = c.Description,
                                 ModelYear = c.ModelYear,
                                 UserName = u.FirstName + " " + u.FirstName,
                                 RentDate = (DateTime)r.RentDate,
                                 ReturnDate = (DateTime)r.ReturnDate
                             };
                return result.SingleOrDefault();
            }
        }
    }
}
