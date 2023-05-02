using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoviesCatalog.DataAccess.Interfaces;
using MoviesCatalog.Web.Models;
using MoviesCatalog.Core.Helpers;
using MoviesCatalog.Web.Auth;
using MoviesCatalog.Core.Models;

namespace MoviesCatalog.Web.Controllers
{
    [Route("Account")]
    public class UserAccountController : Controller
    {
        private readonly IUserAccountService _userAccountService;
        private readonly IAuthToken _authToken;

        public UserAccountController(IUserAccountService userAccountService, IAuthToken authToken)
        {
            this._userAccountService = userAccountService;
            this._authToken = authToken;
        }

        [HttpGet]
        [Route("Roles")]
        [Authorize(Policy = RoleConstant.MOVIE_USER_ROLE)]
        public async Task<IActionResult> GetRoles()
        {
            var result = await _userAccountService.GetUserRoles();

            if (result == null)
                return NotFound($"No user account roles found.");

            return Ok(new Response<List<AccountRole>>(result));
        }

        [HttpPost]
        [Route("Register")]
        [Authorize(Policy = RoleConstant.MOVIE_ADMIN_ROLE)]
        public async Task<IActionResult> CreateUser([FromBody] NewUserView newUser)
        {
            if(!Validator.IsEmailValid(newUser.Email))
                return BadRequest("Email address format is invalid.");

            var role = await _userAccountService.GetUserRolesByName(newUser.Role);

            if (role == null)
                return BadRequest("Entered Role for user does not exits. Please check roles endpoint.");

            var user = await _userAccountService.GetUserByEmail(newUser.Email);

            if(user != null)
                return BadRequest("Account for Email alredy exists.");


            var result = await _userAccountService.CreateUserAccount(
                new Core.Models.UserAccount(){
                AccountRoleId = role.AccountRoleId
                , Name = newUser.Name
                , Email = newUser.Email
                , Password = newUser.Password.EncodeSha256()
            });

            return Ok();
        }

        [HttpPost]
        [Route("Authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> PostAuth([FromBody] LoginView login)
        {
            var result = await _userAccountService.GetUserAuthentication(login.Email, login.Password.EncodeSha256());

            if (result == null)
                return NotFound($"User Account :{login.Email} does not exists.");

            var token = _authToken.GenerateToken(result.AccountId, result.Roles.Name);

            return token == null ? Unauthorized() : Ok(new Response<string>(token));
        }
    }
}
