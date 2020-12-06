using AviaCompany.Core;
using AviaCompany.Planes;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.AviaParkBuilder
{
    public class BelAviaAirParkBuilder : AirParkBuilder
    {
        public AviaPark aviaPark;

        public BelAviaAirParkBuilder()
        {
            this.aviaPark = new AviaPark("Belavia");
        }
       
        public override void BuildBoeing_737_300()
        {            
            aviaPark.planes.Add(new Boeing_737_300($"EW-{new Random().Next(10, 99)}1", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_300($"EW-{new Random().Next(10, 99)}2", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_300($"EW-{new Random().Next(10, 99)}3", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_300($"EW-{new Random().Next(10, 99)}4", new Random().Next(1990, 2021)));
        }

        public override void BuildBoeing_737_500()
        {
            aviaPark.planes.Add(new Boeing_737_500($"EW-{new Random().Next(10, 99)}5", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_500($"EW-{new Random().Next(10, 99)}6", new Random().Next(1990, 2021)));
        }

        public override void BuildBoeing_737_800()
        {
            aviaPark.planes.Add(new Boeing_737_800($"EW-{new Random().Next(10, 99)}7", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_800($"EW-{new Random().Next(10, 99)}8", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_800($"EW-{new Random().Next(10, 99)}9", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_800($"EW-{new Random().Next(10, 99)}10", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_800($"EW-{new Random().Next(10, 99)}11", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Boeing_737_800($"EW-{new Random().Next(10, 99)}12", new Random().Next(1990, 2021)));
        }

       

        public override void BuildEmbraer_E_175()
        {
            aviaPark.planes.Add(new Embraer_E_175($"EW-{new Random().Next(10, 99)}13", new Random().Next(1990, 2021)));
            aviaPark.planes.Add(new Embraer_E_175($"EW-{new Random().Next(10, 99)}14", new Random().Next(1990, 2021)));
        }

        public override void BuildEmbraer_E_195()
        {
            aviaPark.planes.Add(new Embraer_E_195($"EW-{new Random().Next(10, 99)}15", new Random().Next(1990, 2021)));
        }

        public override void BuildBasler_BT_67()
        {
        }

        public override void BuildBoeing_747_LCF_Dreamlifter()
        {
            aviaPark.planes.Add(new Boeing_747_LCF_Dreamlifter($"EW-{new Random().Next(10, 99)}16", new Random().Next(1990, 2021)));
        }

        public override AviaPark GetResult()
        {
            return aviaPark;
        }
    }
}
