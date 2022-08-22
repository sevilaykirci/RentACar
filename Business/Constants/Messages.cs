using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarListed;
        public static string Deleted= "Deleted";
        public static string Updated = "Updated";
        public static string Added= "Added";
        public static string ImageCountOfCar;
        public static string AuthorizationDenied="Dont have autherization";
        public static string RegistrationSuccessful = "Registrated";
        public static User EmailNotFound ;
        public static User PasswordIsIncorrect;
        public static string LoginSuccessful;
        public static string TokenCreated="Giris Basarili";
        public static string UserAlreadyExists;
        public static string Geted;
        public static string Listed;
        public static string EmailIsAlreadyRegistered;
        internal static string PaymentSuccessful;
        internal static string InsufficientCardBalance;
        internal static string CreditCardNotValid;
        internal static string CreditCardNotFound;
        internal static string CustomerCreditCardAlreadySaved;
        internal static string CustomerCreditCardSaved;
        internal static string CustomerCreditCardFailedToSave;
        internal static string CustomerCreditCardNotDeleted;
        internal static string CustomerCreditCardNotFound;
    }
}
