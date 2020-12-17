using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace TextProcessor.ReaderWriter
{
    public class WriterText: IWriterText
    {
       
        public void WriteStringText(string text, string fileName)
        {            
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("PathWrite")+ fileName + ".txt";
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(text);
                }                
            }
            catch (Exception)
            {
                throw new Exception($"Error write file {fileName})");
            }
        }

        public void WriteListStringText(List<string> text, string fileName)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("PathWrite") + fileName + ".txt";
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    text.ForEach(x => streamWriter.WriteLine(x));                    
                }
            }
            catch (Exception)
            {
                throw new Exception($"Error write file {fileName})");
            }
        }

        public void WriteListISentenceText(List<ISentence> text, string fileName)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("PathWrite") + fileName + ".txt";
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach (var sentence in text)
                    {
                        streamWriter.WriteLine();
                        sentence.SentenceElements.ForEach(x => x.Symbols.ForEach(x => streamWriter.Write(x.Character)));
                    } 
                }
            }
            catch (Exception)
            {
                throw new Exception($"Error write file {fileName})");
            }
        }
    }
}
