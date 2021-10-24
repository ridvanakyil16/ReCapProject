using Business.Validate;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarValidateManager : ICarValidateService
    {
        public bool Validate(Car validate)
        {
            if (validate.CarName.Length <= 2 || validate.DailyPrice == 0 )
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
