using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            //Kiralanan arabaların listesini gösterelim.
            Console.WriteLine("List of All Rental Cars:\n");
            Console.WriteLine("No\tDaily Price\tBuying Date\tReturn Date\tRental Days\tTotal Rental Price");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t\t{5}",
                   car.CarId,
                   car.DailyPrice,
                   car.BuyingDate.ToShortDateString(), //Tarih biçiminde yalnızca gün, ay, yılı gösterir.
                   car.ReturnDate.ToShortDateString(),
                   (car.ReturnDate - car.BuyingDate).TotalDays,
                   (car.ReturnDate - car.BuyingDate).TotalDays * car.DailyPrice);
            }

            //Kiralanan arabalarda fiyata göre kıyas yapalım
            Console.WriteLine("\nList of cars with daily rental price between 300 and 500:\n");
            Console.WriteLine("No\tDaily Price\tBuying Date\tReturn Date\tRental Days\tTotal Rental Price");
            foreach (var car in carManager.GetByDailyPrice(100,300))
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t\t{5}",
                    car.CarId,car.DailyPrice,
                    car.BuyingDate.ToShortDateString(),
                    car.ReturnDate.ToShortDateString(),
                    (car.ReturnDate - car.BuyingDate).TotalDays,
                    (car.ReturnDate - car.BuyingDate).TotalDays * car.DailyPrice);
            }

            //Yeni araba ekleyelim
            Console.WriteLine();
            carManager.Add(new Car { 
                CarId=8, 
                BrandId=4, 
                ColorId=3, 
                ModelYear=2017, 
                DailyPrice=100, 
                Description="Ekonomik sınıf araç", 
                BuyingOffice="İzmir Balçova", 
                ReturnOffice="İzmir Menderes", 
                BuyingDate=new DateTime(2021,05,22), 
                ReturnDate=new DateTime(2021,05,28)});
            
            //Yeni eklenen araba ile güncellenen listemizi gösterelim
            Console.WriteLine("\nUpdated List of All Rental Cars:\n");
            Console.WriteLine("No\tDaily Price\tBuying Date\tReturn Date\tRental Days\tTotal Rental Price");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t\t{5}",
                   car.CarId,
                   car.DailyPrice,
                   car.BuyingDate.ToShortDateString(),
                   car.ReturnDate.ToShortDateString(),
                   (car.ReturnDate - car.BuyingDate).TotalDays,
                   (car.ReturnDate - car.BuyingDate).TotalDays * car.DailyPrice);
            }
        }
    }
}
