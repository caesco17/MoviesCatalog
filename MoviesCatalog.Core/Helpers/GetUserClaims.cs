using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MoviesCatalog.Core.Helpers
{
    public static class GetUserClaims
    {
        public static int getUserIDFromClaims(ClaimsIdentity? identity)
        {
            try
            {
                var userId = identity.FindFirst("userId").Value;
                return Int32.Parse(userId);
            }
            catch (Exception ex)
            {
                throw;
            }          
        }
    }
}
