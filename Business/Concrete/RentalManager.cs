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
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var result = CheckCarIsAvaliable(rental);
            if (!result.Success)
            {
                return new ErrorResult(result.Message);
            }
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            var rentals = _rentalDal.GetAll();
            return new SuccessDataResult<List<Rental>>(Messages.RentalListed);
        }

        public IDataResult<List<Rental>> GetAllById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<Rental> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        private  IResult CheckCarIsAvaliable(Rental rental)
        {
            var result = _rentalDal.Get(x => x.CarId == rental.CarId && (x.ReturnDate == null || x.ReturnDate > DateTime.Now));

            if(result != null)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            return new SuccessResult();
        }
    }
}
