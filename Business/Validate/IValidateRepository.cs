using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validate
{
    public interface IValidateRepository<T>
    {
        bool Validate(T validate);
    }
}
