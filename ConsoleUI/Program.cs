using Business.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //AddRental();
            RentalDetails();
            //CarListTest();


        }

        private static void AddRental()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            var result = rentalManager.GetAll();
            if (result.Success == true)
            {
                rentalManager.Add(new Rental
                {
                    CustomerId = 2,
                    CarId = 7,
                    RentDate = new DateTime(2021, 03, 22),
                    ReturnDate = new DateTime(2021, 03, 27)
                });
            }
        }
        private static void AddCustomer(CustomerManager customerManager)
        {
            var result = customerManager.GetAll();
            if (result.Success == true)
            {
                customerManager.Add(new Customer
                {
                    CompanyName = "Hyundai"
                });
            }
            
        }
        private static void GetCustomer()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            var result = customerManager.GetAll();
            if (result.Success == true)
            {
                Console.WriteLine("\nUpdated List of All Customers:\n");
                Console.WriteLine("No\tCompany Name");
                foreach (var customer in result.Data)
                {
                    Console.WriteLine("{0}\t{1}", customer.UserId, customer.CompanyName);
                }
            }
        }
        private static void CarListTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                Console.WriteLine("Car Id\t\tCar Name\t\tCar's Color\tTotal Rental Price");
                Console.WriteLine("----------\t---------\t\t------------\t------------------");
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0}\t\t{1}\t\t{2}\t\t{3}", 
                        car.CarId, 
                        car.BrandName.Trim(), 
                        car.ColorName.Trim(), 
                        car.DailyPrice);
                }
            }
        }
        private static void RentalDetails()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            
            var result = rentalManager.GetRentalDetails();
            if (result.Success == true)
            {
                Console.WriteLine("List of All Rental Cars:\n");
                Console.WriteLine("Car Name\tColor Name\tDaily Price\tUser Name\tRent Date\tReturn Date\tTotal Rental Day\tTotal Rental Price");
                foreach (var rental in result.Data)
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}\t\t{3}\t{4}\t{5}\t{6}\t{7}",
                        rental.CarName.Trim(), 
                        rental.ColorName.Trim(), 
                        rental.DailyPrice, 
                        rental.UserName.Trim(),
                        rental.RentDate.ToShortDateString(), 
                        rental.ReturnDate.ToShortDateString(),
                        (rental.ReturnDate - rental.RentDate).TotalDays,
                        (rental.ReturnDate - rental.RentDate).TotalDays * rental.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void AddCarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car
            {
                BrandId = 2,
                ColorId = 3,
                ModelYear = 2013,
                DailyPrice = 450,
                Description = "Orta sınıf araç",
                RentOfficeId = 3,
                ReturnOfficeId = 5,
                BuyingDate = new DateTime(2021, 11, 12),
                ReturnDate = new DateTime(2021, 11, 17)
            });
        }
        private static void UpdatedCarList()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                Console.WriteLine("\nUpdated List of All Rental Cars:\n");
                Console.WriteLine("No\tDaily Price\tBuying Date\tReturn Date\tRental Days\tTotal Rental Price");
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0}\t{1}\t\t{2}\t{3}\t{4}\t\t{5}",
                    car.CarId,
                    car.DailyPrice,
                    car.RentDate.ToShortDateString(),
                    car.ReturnDate.ToShortDateString(),
                    (car.ReturnDate - car.RentDate).TotalDays,
                    (car.ReturnDate - car.RentDate).TotalDays * car.DailyPrice);
                }
            }
        }
    }
}