using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
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
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            UserManager userManager = new UserManager(new EfUserDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());


            TestCarRentalApplication(carManager);
            //TestGetAllCars(carManager);
            //TestGetCarById(carManager); 
            //TestAddCar(carManager);
            //TestDeleteCar(carManager);
        }

        private static void TestCarRentalApplication(CarManager carManager)
        {
            Console.WriteLine("*****************************************\n" +
                              "*** Welcome to our car rental company!***\n" +
                                    "***** You just say it! * ****\n" +
                                     "****Have a nice trip ****\n");

        }

        //private static void TestGetAllCars(CarManager carManager)
        //{
        //    var result = carManager.GetAll();

        //    if (result.Success)
        //    {
        //        foreach (var car in result.Data)
        //        {
        //            Console.WriteLine(car.CarId + "-" + car.CarName + "-" + car.DailyPrice + "-" + car.Description);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);

        //    }
        //}
        //private static void TestGetCarById(CarManager carManager)
        //{
        //    var result = carManager.GetById(1);

        //    if (result.Success)
        //    {
        //        Console.WriteLine(result.Data.CarId + "-" + result.Data.CarName + "-" + result.Data.DailyPrice + "-" + result.Data.Description);
        //    }
        //    else
        //    {
        //        Console.WriteLine(result.Message);
        //    }
        //}

        //    private static void TestAddCar(CarManager carManager)
        //{
        //    var result = carManager.Add(new Car { BrandId = 3, ColorId = 3, CarName = "Audi", ModelYear = 2020, DailyPrice = 13000, Description = "Audi Automatic Gear" });
        //    Console.WriteLine(result.Message);
        //}
        //private static void TestDeleteCar(CarManager carManager)
        //{

        //    var result = carManager.Delete(new Car { CarId = 3 });
        //    Console.WriteLine(result.Message);
        //}

    }
}








