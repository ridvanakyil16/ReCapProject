using Core.Utilities.Results;
using Entites.Concrete;
using Entites.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IRepsoitoryService<Car>
    {
        public IDataResult<List<CarDetailsDto>> GetCarDetail();
    }
}
