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
            catch(Exception e)
            {
                Console.WriteLine($"Error in method ReadTextString() whith {e} ");
            }         
        }*/

        //Второй метод///////////////////////////////////////////////////////////////////////// 
        public void ReadTextString(IParser parser)
        {
            if (parser!=null)
            {
                try
                {
                    using (StreamReader streamReader = new StreamReader(filePath))
                    {
                        string line;
                        while ((line = streamReader.ReadLine()) != null)
                        {
                            parser.ParserLineTextBySymbols(line);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error in method ReadTextString() whith {e} ");
                }
            }           
        }

    }
}

