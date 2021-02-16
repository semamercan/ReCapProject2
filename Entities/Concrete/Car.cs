using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
        public int RentOfficeId { get; set; }
        public int ReturnOfficeId { get; set; }
        public DateTime BuyingDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
