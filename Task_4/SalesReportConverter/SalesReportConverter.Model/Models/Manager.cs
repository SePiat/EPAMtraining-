using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.Model.Models
{
    public class Manager
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public virtual ICollection<Buyer> Buyers { get; set; }
    }
}
