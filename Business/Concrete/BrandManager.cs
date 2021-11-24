using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {

        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand entity)
        {
                _brandDal.Add(entity);
                return new SuccessResult(Messages.BrandAdded);
        }

        public IResult Delete(Brand entity)
        {
                _brandDal.Delete(entity);
                return new SuccessResult(Messages.BrandDeleted);
        }
        public IResult Update(Brand entity)
        {
                _brandDal.Update(entity);
                return new SuccessResult(Messages.BrandUpdated);
        }
        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(), Messages.BrandsListed);
        }

        public IDataResult<List<Brand>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(p => p.BrandId == id), Messages.BrandsListed);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(p => p.BrandId == id), Messages.BrandListed);
        }
    }
}
