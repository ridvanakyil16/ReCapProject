using Business.Abstract;
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

        public void Add(Brand entity)
        {
            _brandDal.Add(entity);
        }

        public void Delete(Brand entity)
        {
            _brandDal.Delete(entity);
        }
        public void Update(Brand entity)
        {
            _brandDal.Update(entity);
        }
        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public List<Brand> GetAllById(int id)
        {
            return _brandDal.GetAll(p => p.BrandId == id);
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(p => p.BrandId == id);
        }
    }
}
