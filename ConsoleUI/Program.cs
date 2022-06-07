using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ICarService carService = new CarManager(new EfCarDal());
            //Console.WriteLine(carService.GetAllByColorId(1));
            //ListBrandsName();

            ICarService carService = new CarManager(new EfCarDal());
            var cars = carService.GetAll().Data;
            foreach (var item in cars)
            {
                Console.WriteLine(item.Id+" " + item.Name+" " + item.ModelYear+" " + item.ColorId+ " " + item.BrandId+ " " + item.DailyPrice + " " + item.Description );
            } 
        }

        private static void ListBrandsName()
        {
            IBrandService brandService = new BrandManager(new EfBrandDal());
            var result = brandService.GetAll().Data;
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
