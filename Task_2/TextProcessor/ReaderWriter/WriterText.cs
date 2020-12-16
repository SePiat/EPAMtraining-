using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace TextProcessor.ReaderWriter
{
    public class WriterText: IWriterText
    {
        private readonly string filePath = ConfigurationManager.AppSettings.Get("PathWrite");
        public void WriteText(string text)
        {            
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(text);
                }                
            }
            catch (Exception)
            {
                throw new Exception("Wrong write path");
            }
        }
    }
}
