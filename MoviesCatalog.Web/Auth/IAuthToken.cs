using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.Web.Auth
{
    public interface IAuthToken
    {
        string GenerateToken(int UserId, string Role);
    }
}
