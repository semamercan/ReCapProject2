using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentCarContext>, ICustomerDal
    {
        /*public List<CustomerDetailDto> GetCustomersDetail()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from us in context.Users
                             join cus in context.Customers
                             on us.Id equals cus.UserId
                             select new DtoCustomerDetail
                             {
                                 UserId = us.Id,
                                 UserName = us.FirstName + " " + us.LastName,
                                 Email = us.Email,
                                 CompanyName = cus.CompanyName
                             };
                return result.ToList();
            }
        }*/
    }
}
