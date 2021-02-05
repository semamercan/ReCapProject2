using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars; //Class içinde, metotların üstünde tanımlandığı için global değişkendir. Bu yüzden _ ile tanımlarız.
        public InMemoryCarDal() //constructor
        {
            _cars = new List<Car> //Car listesi oluşturulur.
            {
                new Car { CarId = 1, BrandId = 1, ColorId = 1, ModelYear = 2001, DailyPrice = 200, Description = "Ekonomik araç", BuyingOffice = "Ankara Esenboğa Havalimanı", ReturnOffice = "Ankara Söğütözü", BuyingDate = new DateTime(2021, 2, 2), ReturnDate = new DateTime(2021, 2, 3) },
                new Car { CarId = 2, BrandId = 2, ColorId = 3, ModelYear = 2010, DailyPrice = 250, Description = "Orta sınıf araç", BuyingOffice = "İstanbul Ataşehir", ReturnOffice = "İstanbul Ataşehir", BuyingDate = new DateTime(2021, 2, 20), ReturnDate = new DateTime(2021, 2, 21) },
                new Car { CarId = 3, BrandId = 3, ColorId = 5, ModelYear = 2015, DailyPrice = 360, Description = "Orta sınıf araç", BuyingOffice = "İzmir Alsancak", ReturnOffice = "İzmir Adnan Menderes Havalimanı", BuyingDate = new DateTime(2021, 3, 10), ReturnDate = new DateTime(2021, 3, 25) },
                new Car { CarId = 5, BrandId = 1, ColorId = 1, ModelYear = 2019, DailyPrice = 420, Description = "Üst sınıf araç", BuyingOffice = "Antalya Havalimanı", ReturnOffice = "Antalya Havalimanı", BuyingDate = new DateTime(2021, 4, 1), ReturnDate = new DateTime(2021, 4, 7) },
            };
    }
        public void Add(Car entity)
        {
            _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars; //Veritabanını olduğu gibi gönderir.
        }

        public void Update(Car entity)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
            carToUpdate.CarId = entity.CarId;
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.DailyPrice = entity.DailyPrice;
            carToUpdate.Description = entity.Description;
            carToUpdate.BuyingOffice = entity.BuyingOffice;
            carToUpdate.ReturnOffice = entity.ReturnOffice;
            carToUpdate.BuyingDate = entity.BuyingDate;
            carToUpdate.ReturnDate = entity.ReturnDate;
        }
    }
}
