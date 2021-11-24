using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public IResult Add(Color entity)
        {
                _colorDal.Add(entity);
                return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color entity)
        {
                _colorDal.Delete(entity);
                return new SuccessResult(Messages.ColorDeleted);
        }
        public IResult Update(Color entity)
        {
                _colorDal.Update(entity);
                return new SuccessResult(Messages.ColorUpdated);
        }
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        public IDataResult<List<Color>> GetAllById(int id)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(p => p.ColorId == id), Messages.ColorsListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(p => p.ColorId == id), Messages.ColorListed);
        }
    }
}
