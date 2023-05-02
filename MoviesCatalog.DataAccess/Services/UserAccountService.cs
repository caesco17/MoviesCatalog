using Microsoft.EntityFrameworkCore;
using MoviesCatalog.Core.Models;
using MoviesCatalog.DataAccess.Data;
using MoviesCatalog.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.DataAccess.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly DataContext _dataContext;

        public UserAccountService(DataContext dataContext) {
            this._dataContext = dataContext;
        }
            
        public async Task<UserAccount> CreateUserAccount(UserAccount userAccount)
        {
            _dataContext.UserAccounts.Add(userAccount);
            await _dataContext.SaveChangesAsync();

            return userAccount;
        }

        public async Task<UserAccount> GetUserAuthentication(string Email, string Password)
        {
            var _user = await _dataContext.UserAccounts.Where(a => a.Email == Email && a.Password == Password).FirstOrDefaultAsync();

            if(_user is not null)
                _user.Roles = await _dataContext.AccountRoles.Where(a => a.AccountRoleId == _user.AccountRoleId).FirstOrDefaultAsync();

            return _user;
        }

        public async Task<UserAccount> GetUserByEmail(string Email)
        {
            return await _dataContext.UserAccounts.Where(a => a.Email == Email).FirstOrDefaultAsync();                     
        }

        public async Task<UserAccount> GetUserById(int userId)
        {
            return await _dataContext.UserAccounts.Where(a => a.AccountId == userId).FirstOrDefaultAsync();
        }

        public async Task<List<AccountRole>> GetUserRoles()
        {
            return  await _dataContext.AccountRoles.ToListAsync();
        }

        public async Task<AccountRole> GetUserRolesByName(string RoleName)
        {
            return await _dataContext.AccountRoles.Where(a => a.Name == RoleName).FirstOrDefaultAsync();
        }
    }
}
