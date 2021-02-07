using System.Collections.Generic;

namespace SalesReportConverter.Model_.Models
{
    public class Buyer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<Buying> Buyings { get; set; }

    }
}
