using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entites.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal(),new CarValidateManager());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());


            Console.WriteLine("=============== Araba İd'sine Göre Araba Getirme ===============");
            Console.WriteLine(carManager.GetById(3).CarName);

            Console.WriteLine("");
            Console.WriteLine("=============== Araba İd'sine Göre Arabanın Özelliklerini Getirme ===============");
            foreach (var car in carManager.GetAllById(3))
            {
                Console.WriteLine(car.CarId +" "+ car.CarName + " " + car.BrandId + " " + car.ColorId + " " + car.DailyPrice + " " + car.Description);
            }

            Console.WriteLine("");
            Console.WriteLine("=============== Renk İd'sine Göre Araba Getirme ===============");

            Console.WriteLine("");
            Console.WriteLine("=============== Marka İd'sine Göre Araba Getirme ===============");

            //Console.WriteLine("");
            //Console.WriteLine("=============== Araç Ekleme ===============");
            //Car car = new Car();
            //car.CarName = "Tesla";
            //car.BrandId = 1;
            //car.ColorId = 1;
            //car.DailyPrice = 2000;
            //car.Description = "Tesla Sıfır Kiralık Araç";
            //carManager.Add(car);

            //Console.WriteLine("");
            //Console.WriteLine("=============== Araç Güncelleme ===============");
            //Car car2 = new Car();
            //car2.CarId = 3;
            //car2.CarName = "Tesla";
            //car2.BrandId = 1;
            //car2.ColorId = 1;
            //car2.DailyPrice = 2000;
            //car2.Description = "Tesla Sıfır Kiralık Araç";
            //carManager.Update(car2);


            //Console.WriteLine("");
            //Console.WriteLine("=============== Araç Silme ===============");
            //Car car3 = new Car();
            //car3.CarId = 5003;
            //carManager.Delete(car3);

            Console.WriteLine("");
            Console.WriteLine("=============== Araç Detayları ===============");

            foreach (var car in carManager.GetCarDetail())
            {
                Console.WriteLine(car.CarId + " " + car.CarName + " " + car.BrandName + " " + car.ColorName + " " + car.DailyPrice);
            }

            Console.WriteLine("");
            Console.WriteLine("=============== Tüm Araçlar ===============");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarId + " " + car.CarName + " " + car.DailyPrice);
            }
        }
    }
}
