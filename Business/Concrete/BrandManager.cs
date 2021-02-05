using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public void Add(Brand brand)
        {
            if(brand.BrandName.Length>=2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("The car has been successfully added.");
            }
            else
            {
                throw new Exception("The car name must have a minimum of 2 characters.");
            }
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("The brand has been successfully deleted.");
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetCarsByBrandId(int id)
        {
            return _brandDal.GetAll(b => b.BrandId == id);
        }

        public void Update(Brand brand)
        {
            if(brand.BrandName.Length>=2)
            {
                _brandDal.Delete(brand);
                Console.WriteLine("The brand has been successfully updated.");
            }
            else
            {
                throw new Exception("The car name must have a minimum of 2 characters.");
            }
        }
    }
}
