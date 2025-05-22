using PosLibrary.Repo;
using PosLibrary.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosLibrary.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepo;
        public UserService(UserRepository userRepo) {
           _userRepo = userRepo;
        }

        public User? Authenticate(string username, string pass)
        {
            return _userRepo.GetByUser(username, pass);
        }
    }
}
