using Business.Concrete;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
            Console.WriteLine("-------------- İd ye Göre Fiyat ve Araba Getirme. --------------");
            Console.WriteLine(carManager.GetById(1).Description);
            Console.WriteLine("Fiyat : " + " " + carManager.GetById(1).DailyPrice + "TL");
        }
    }
}
