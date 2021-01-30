using SalesReportConverter.BL.WatcherService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace SalesReportConverter.BL.CSVHandler
{
    public class Reader
    {  
        private readonly string filePath = ConfigurationManager.AppSettings.Get("WatcherFolderPath");
        public ICollection<string> ReadStrings(string nameFile)
        {
            ICollection<string> strings = new List<string>();
            try
            {
                using (StreamReader sr = new StreamReader(filePath+nameFile, System.Text.Encoding.ASCII))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        strings.Add(line.ToString());                      
                    }                    
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in method ReadTextString() whith {e} ");
            }
            return strings;
        }
    }
}
