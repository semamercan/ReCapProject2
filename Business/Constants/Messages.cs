using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages //Statik olmasındaki temel amaç hafızada tek yer tutmak.
    {
        public static string CarAdded = "The car has been successfully added";
        public static string CarListed = "The car has been successfully listed.";
        public static string CarDailyPriceInvalid = "Car rental daily fee must be greater than 0.";
        public static string CarUpdated = "The car has been successfully updated.";
        public static string CarDeleted = "The car has been successfully deleted.";

        public static string CustomerAdded = "The customer has been successfully added.";
        public static string CustomerUpdated = "The customer has been successfully updated.";
        public static string CustomerDeleted = "The customer has been successfully deleted.";
        public static string CustomerListed = "The customer has been successfully listed.";

        public static string RentalAdded = "The rental has been successfully added.";
        public static string RentalUpdated = "The rental has been successfully updated.";
        public static string RentalDeleted = "The rental has been successfully deleted.";
        public static string RentalReturnDateIsNull = "The car has not been returned.";
        public static string RentalListed = "The rental has been successfully listed.";

        public static string UserAdded = "The user has been successfully added";
        public static string UserUpdated = "The user has been successfully updated.";
        public static string UserDeleted = "The user has been successfully deleted.";
        public static string UserListed = "The user has been successfully listed.";


        public static string BrandNameInvalid = "The car name must have a minimum of 2 characters.";
        public static string BrandAdded = "The brand has been successfully added.";
        public static string BrandUpdated = "The brand has been successfully updated.";
        public static string BrandDeleted = "The brand has been successfully deleted.";
        public static string BrandReturnDateIsNull = "The brand has not been returned.";
        public static string BrandListed = "The brand has been successfully listed.";
        
        public static string ColorListed = "The color has been successfully listed.";
        public static string ColorAdded = "The color has been successfully added.";
        public static string ColorUpdated = "The color has been successfully updated.";
        public static string ColorDeleted = "The color has been successfully deleted.";

        public static string UndeliveredCar = "The car cannot be rented because it is not delivered.";
        public static string DeliveredCar = "The car can be rented.";
        public static string ImageCountOfCarError = "The car can have up to 5 images";

        public static string CarImageListed = "The car image has been successfully listed.";
        public static string CarImageAdded = "The car image has been successfully added.";
        public static string CarImageUpdated = "The car image has been successfully updated.";
        public static string CarImageDeleted = "The car image has been successfully deleted.";

        public static string AuthorizationDenied = "You have no authority.";
        public static string UserNotFound = "User not found.";
        public static string PasswordError = "Password Error";
        public static string SuccessfullLogin = "Successfull Login";
        public static string UserAlreadyExists = "User already exists.";
        public static string UserRegistered = "The registration has been successfully created.";
        public static string AccessTokenCreated = "Access token has been successfully created.";
    }
}
