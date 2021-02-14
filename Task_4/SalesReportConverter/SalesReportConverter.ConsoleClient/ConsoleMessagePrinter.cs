using System;

namespace SalesReportConverter.ConsoleClient
{
    public static class ConsoleMessagePrinter
    {
        public static void WriteMessageInConsole(object sender, string message)
        {
            Console.WriteLine(message);
        }
    }
}
