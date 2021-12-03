using Core.Entites.Concrete;
using Core.Utilities.Results;
using Entites.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IRepsoitoryService<User>
    {
        IDataResult<List<OperationClaim>> ClaimsGet(User user);
        IDataResult<User> Email(string email);  
    }
}
