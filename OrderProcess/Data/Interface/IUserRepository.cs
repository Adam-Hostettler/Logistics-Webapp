using System.Collections.Generic;

namespace OrderProcess.Data.Interface
{
    public interface IUserRepository
    {
        void Create(UserDTO User);
        IEnumerable<UserDTO> GetAllUsers();
    }
}