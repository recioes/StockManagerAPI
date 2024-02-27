using StockAPI.Core.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Extensions
{
    public static class RoleClaimExtension
    {
        public static IEnumerable<Claim> GetClaims(this User user)
        {
            var result = new List<Claim>
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Roles.Name),
                new(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            //result.AddRange(
            //    user.Roles.Select(role => new Claim(ClaimTypes.Role, role.Name))
            //);
            return result;
        }
    }
}
