using Business.Abstract;
using Business.Business.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IBrandService _brandService;

        public CarManager(ICarDal carDal, IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof (CarValidator))]
        public IResult Add(Car entity)
        {
            var result =  BusinessRules.Run(CheckIfCarCountOfCategoryCorrect(entity.CarId), CheckIfCarNameExists(entity.CarName),CheckIfBrandLimitExceded());

            if(result != null)
            {
                return result;
            }
            _carDal.Add(entity);
            return new SuccessResult(Messages.CarAdded);

        }
        public IResult Delete(Car entity)
        {
                _carDal.Delete(entity);
                return new SuccessResult(Messages.CarDeleted);     
        }
        public IResult Update(Car entity)
        {
                _carDal.Update(entity);
                return new SuccessResult(Messages.CarUpdated);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            if(DateTime.Now.Hour == 1)
            {
                return new ErrorDataResult<List<Car>>(Messages.MainTenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarsListed);
        }
        
        public IDataResult<List<Car>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.CarId == id), Messages.CarsListed); 
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            return new SuccessDataResult<Car>(_carDal.Get(p => p.CarId == id), Messages.CarListed);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailsDto>> (_carDal.GetCarDetail(),Messages.CarsListed);
        }

        private IResult CheckIfCarCountOfCategoryCorrect(int carId)
        {
            var result = _carDal.GetAll(p => p.CarId == carId).Count;
            if (result > 15)
            {
                return new ErrorResult(Messages.CarCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCarNameExists(string carName)
        {
            var result = _carDal.GetAll(p => p.CarName == carName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExsist);
            }
            return new SuccessResult();
        }

       private IResult CheckIfBrandLimitExceded()
        {
            var result = _brandService.GetAll();
            if(result.Data.Count > 15)
            {
                return new ErrorResult(Messages.BrandLimitExceded);
            }
            return new SuccessResult();
        }
    }
}
