using Business.Abstract;
using DataAccess.Abstract;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color entity)
        {
            _colorDal.Add(entity);
        }

        public void Delete(Color entity)
        {
            _colorDal.Delete(entity);
        }
        public void Update(Color entity)
        {
            _colorDal.Update(entity);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetAllById(int id)
        {
            return _colorDal.GetAll(p => p.ColorId == id);
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(p => p.ColorId == id);
        }
    }
}
