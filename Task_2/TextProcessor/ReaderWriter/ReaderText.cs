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

        //Первый метод/////////////////////////////////////////////////////////////////////////
        /*public string ReadTextAll()
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
            catch
            {
                throw new Exception("Error in method ReadTextString()");
            }            
        }*/

        //Второй метод///////////////////////////////////////////////////////////////////////// 
        public string ReadTextString(IParser parser)
        {            
            try
            {
                using (StreamReader streamReader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        parser.ParserTextBySymbols(line);
                    }
                }
                return  null;
            }
            catch
            {
                throw new Exception("Error in method ReadTextString() ");
            }
        }

    }
}

