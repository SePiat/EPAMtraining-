﻿using AutomaticTelephoneExchange.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange.Client
{
    public class Сlient : IСlient
    {
        public string Name { get; set ; }
        public string LastName { get; set; }
        public string Birthday { get; set; }
        public IClientTerminal clientTerminal { get; set; }
        public IPort port { get; set; }

    }
}
