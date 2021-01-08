using System;
using System.Collections.Generic;
using System.Text;

namespace AutomaticTelephoneExchange
{
    public static class ConsoleMessagePrinter
    {       
        public static void WriteMessageInConsole(object sender, string message)
        {            
            Console.WriteLine(message);
        }
    }
}
