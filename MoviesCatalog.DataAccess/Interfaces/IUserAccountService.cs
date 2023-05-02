using MoviesCatalog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.DataAccess.Interfaces
{
    public interface IUserAccountService
    {
        public Task <UserAccount> GetUserByEmail (string Email);
        public Task<List<AccountRole>> GetUserRoles();
        public Task<AccountRole> GetUserRolesByName(string RoleName);
        public Task<UserAccount> GetUserById(int userId);
        public Task<UserAccount> GetUserAuthentication(string Email,string Password);
        public Task<UserAccount> CreateUserAccount(UserAccount userAccount);
    }
}
