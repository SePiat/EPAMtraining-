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

        public void Test(List<ISentence> text)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("Test");
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach (var sentence in text)
                    {
                        streamWriter.WriteLine();
                        sentence.SentenceElements.ForEach(x => x.Symbols.ForEach(x => streamWriter.Write(x.Character)));
                    }
                }
            }
            catch
            {
                throw new Exception("Error write file Test()");
            }
        }
        public void WriteStringText(string text)
        {            
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("String");
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(text);
                }                
            }
            catch
            {
                throw new Exception($"Error write file WriteStringText()");
            }
        }

        public void WriteWordsSetLengthByQuestionableSentence(List<string> text)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("WordsSetLengthByQuestionableSentence");
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    text.ForEach(x => streamWriter.WriteLine(x));                    
                }
            }
            catch
            {
                throw new Exception($"Error write file WriteWordsSetLengthByQuestionableSentence()");
            }
        }

        public void WriteListISentenceText(List<ISentence> text)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("SentencesOrderByTheNumberOfWords");
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach (var sentence in text)
                    {
                        streamWriter.WriteLine();
                        sentence.SentenceElements.ForEach(x => x.Symbols.ForEach(x => streamWriter.Write(x.Character)));
                    } 
                }
            }
            catch
            {
                throw new Exception ("Error write file SentencesOrderByTheNumberOfWords()");
            }
        }

        public void WriteWordsSetLengthByQuestionableSentence(List<ISentenceElement> words)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("WordsSetLengthByQuestionableSentence");
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach (var word in words)
                    {
                        streamWriter.WriteLine();
                        word.Symbols.ForEach(x => streamWriter.Write(x.Character));
                    }
                }
            }
            catch
            {
                throw new Exception("Error write file WordsSetLengthByQuestionableSentence()");
            }
        }
    }
}
