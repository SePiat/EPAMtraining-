using AviaCompany.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany
{
    public class Flight
    {
        public string  Name {get;set;}
        public IPlane Carrier { get; set; }
        public int Distance { get; set; }
        public int NumberOfPassengrsEconomyClass { get; set; }
        public int NumberOfPassengrsBusinessClass { get; set; }
        public int WeightOfCargo { get; set; }



    }
}
