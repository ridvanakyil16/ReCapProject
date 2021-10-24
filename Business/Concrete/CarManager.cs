using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        CarValidateManager _carValidateManager;

        public CarManager(ICarDal carDal, CarValidateManager carValidateManager)
        {
            _carDal = carDal;
            _carValidateManager = carValidateManager;
        }

        public void Add(Car entity)
        {
            if(_carValidateManager.Validate(entity) == true)
            {
                Console.WriteLine("ARAÇ EKLENEMEDİ! ARAÇ ADI 2 KARAKTERDEN AZ OLAMAZ VE FİYAT 0 OLAMAZ");
            }
            else
            {
                Console.WriteLine("ARAÇ BAŞARIYLA EKLENDİ! EKLENEN ARAÇ : " + entity.CarName);
                _carDal.Add(entity);
            } 
        }
        public void Delete(Car entity)
        {
            _carDal.Delete(entity);
        }
        public void Update(Car entity)
        {
            _carDal.Update(entity);
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllById(int id)
        {
            return _carDal.GetAll(p => p.CarId == id);
        }

        public Car GetById(int id)
        {
            return _carDal.Get(p => p.CarId == id);
        }

        public List<CarDetailsDto> GetCarDetail()
        {
            return _carDal.GetCarDetail();
        }
    }
}
