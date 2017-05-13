using System;
using TimeRegistration.Core.Dtos;

namespace TimeRegistration.Core.Repositories.Abstructions
{
    public interface IUserRepository
    {
        int Insert(string userName);
        User GetUser(int userId);
        void DeleteUser(int userId);
        PagedList<User> GetUserList(int page, int pageSize);
    }
}
