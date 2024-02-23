using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Models.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Slug { get; set; }
        public int RolesId { get; set; }
        public Role Roles { get; set; }


    }
}
