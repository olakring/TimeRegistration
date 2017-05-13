using System;
using TimeRegistration.Core.Dtos;
using TimeRegistration.Core.Managers.Abstructions;
using TimeRegistration.Core.Repositories.Abstructions;

namespace TimeRegistration.Core.Managers.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int CreateUser(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new ArgumentException();
            }

            return _userRepository.Insert(userName);
        }

        public User GetUser(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException();
            }

            return _userRepository.GetUser(userId);
        }

        public void DeleteUser(int userId)
        {
            if (userId <= 0)
            {
                throw new ArgumentException();
            }

            _userRepository.DeleteUser(userId);
        }

        public PagedList<User> GetUserList(int page, int pageSize)
        {
            return _userRepository.GetUserList(page, pageSize);
        }
    }
}
