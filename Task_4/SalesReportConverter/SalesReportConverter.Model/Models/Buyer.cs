using System;
using System.Collections.Generic;
using System.Text;

namespace SalesReportConverter.Model.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public virtual ICollection<Buying> Buyings { get; set; }
        

    }
}
