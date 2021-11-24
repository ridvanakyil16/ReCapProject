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
            CarManager carManager = new CarManager(new EfCarDal(), new BrandManager(new EfBrandDal()));
            ColorManager colorManager = new ColorManager(new EfColorDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            UserManager userManager = new UserManager(new EfUserDal());
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());


            RentalAdd(rentalManager);
            //CustomerAdd(customerManager);

        }

        private static void CustomerAdd(CustomerManager customerManager)
        {
            Customer customer = new Customer();
            customer.UserId = 4;
            customer.CompanyName = "Soft";

            var result = customerManager.Add(customer);
            if (result.Success == true)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                customerManager.Add(customer);
                Console.WriteLine(result.Message);
            }
        }

        private static void RentalAdd(RentalManager rentalManager)
        {
            Rental rental = new Rental();
            rental.CarId = 1;
            rental.CustomerId =4;
            rental.RentDate = new DateTime(2021,11,1);
            
            var result = rentalManager.Add(rental);
            Console.WriteLine(result.Message);
        }
    }
}
