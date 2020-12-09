using AviaCompany.AviaParkBuilder;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviaCompany.AviaParkBuilder
{
    public class AirParkForBelAviaCreator
    {
        AirParkBuilder builder;

        public AirParkForBelAviaCreator(AirParkBuilder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildBoeing_737_300();
            builder.BuildBoeing_737_500();
            builder.BuildBoeing_737_800();
            builder.BuildEmbraer_E_175();
            builder.BuildEmbraer_E_195();
            builder.BuildBasler_BT_67();
            builder.BuildBoeing_747_LCF_Dreamlifter();
        }

       
    }
}
