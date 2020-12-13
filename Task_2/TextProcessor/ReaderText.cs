using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;

namespace TextProcessor
{
    public class ReaderText
    {
        private string filePath= ConfigurationManager.AppSettings.Get("PathFile");
        public string ReadText()
        {
            string text;
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    text = sr.ReadToEnd();
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

