using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeRegistration.Core.Dtos;

namespace TimeRegistration.Core.Managers.Abstructions
{
    public interface IUserManager
    {
        int CreateUser(string userName);

        User GetUser(int userId);

        void DeleteUser(int userId);

        PagedList<User> GetUserList(int page, int pageSize);
    }
}
