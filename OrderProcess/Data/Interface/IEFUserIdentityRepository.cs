using System.Collections.Generic;
using OrderProcess.Data.EntityFramework;

namespace OrderProcess.Data.Interface
{
    public interface IEFUserIdentityRepository
    {
        IEnumerable<UserIdentityModel> GetAllUsers();
        string GetClerk();

    }
}