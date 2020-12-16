using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using TextProcessor.Core;

namespace TextProcessor
{
    public class ReaderText: IReaderText
    {
        private readonly string filePath= ConfigurationManager.AppSettings.Get("PathRead");
        public string ReadText()
        {
            string text;
            try
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    text = streamReader.ReadToEnd();
                }
                return text;
            }
            catch (Exception)
            {
                throw new Exception("Wrong source path");
            }            
        } 
       
    }
}

