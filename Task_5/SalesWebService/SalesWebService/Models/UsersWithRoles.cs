using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebService.Models
{
    public class UsersWithRoles
    {
     

        public string user { get; set; }
        public IEnumerable<string> role { get; set; }
    }
}
