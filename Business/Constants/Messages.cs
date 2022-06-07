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
        internal static string RegistrationSuccessful;
        internal static User EmailNotFound;
        internal static User PasswordIsIncorrect;
        internal static string LoginSuccessful;
        internal static string TokenCreated;
        internal static string UserAlreadyExists;
        internal static string Geted;
        internal static string Listed;
        internal static string EmailIsAlreadyRegistered;
    }
}
