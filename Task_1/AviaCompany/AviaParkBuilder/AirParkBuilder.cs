using AviaCompany.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.AviaParkBuilder
{
    public abstract class AirParkBuilder
    {
        public abstract void BuildBoeing_737_300();
        public abstract void BuildBoeing_737_500();
        public abstract void BuildBoeing_737_800();
        public abstract void BuildEmbraer_E_175();
        public abstract void BuildEmbraer_E_195();
        public abstract void BuildBasler_BT_67();
        public abstract void BuildBoeing_747_LCF_Dreamlifter();

        public abstract AviaPark GetResult();
      
    }
}
