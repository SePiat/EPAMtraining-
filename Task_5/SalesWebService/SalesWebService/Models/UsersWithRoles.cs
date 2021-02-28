using System.Collections.Generic;

namespace SalesWebService.Models
{
    public class UsersWithRoles
    {


        public string user { get; set; }
        public IEnumerable<string> role { get; set; }
    }
}
