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

        public void WriteWordsSetLengthByQuestionableSentences(List<string> text)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("WordsSetLengthByQuestionableSentences");
                WriteListString(text, filePath);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error in method WriteWordsSetLengthByQuestionableSentences() :{ex}");
            }
        }

        public void WriteSentencesOrderByTheNumberOfWords(List<ISentence> text)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("SentencesOrderByTheNumberOfWords");
                WriteListISentenceText(text, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in method file WriteSentencesOrderByTheNumberOfWords() :{ex}");
            }
        }


        public void WriteQuestionableSentences(List<ISentence> text)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("QuestionableSentences");
                WriteListISentenceText(text, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in method file WriteQuestionableSentences()  :{ex}");
            }
        }

        public void WriteWordsSetLengthByQuestionableSentences(List<ISentenceElement> words)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("WordsSetLengthByQuestionableSentences");
                WriteISentenceElement(words, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in method WriteWordsSetLengthByQuestionableSentences()  :{ex}");
            }
        }


        public void WriteTextModel(ITextModel textModel)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("TextModel");
                WriteTextModel(textModel, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in method WriteTextModel() :{ex}");
            }
        }
        public void WriteTextModelWithoutWordsOfSetLengthWithСonsonantLetter(ITextModel textModel)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("TextModelWithoutWordsOfSetLengthWithСonsonantLetter");
                WriteTextModel(textModel,  filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in method WriteTextModelWithoutWordsOfSetLengthWithСonsonantLetter()  :{ex}");
            }
        }

        public void WriteTextModelExchangeWordOfSetLengthWhithString(ITextModel textModel)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("TextModelExchangeWordOfSetLengthWhithString");
                WriteTextModel(textModel, filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in method WriteTextModelExchangeWordOfSetLengthWhithString()  :{ex}");
            }
        }




        private void WriteTextModel(ITextModel textModel, string filePath)
        {
            if (textModel!=null)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    textModel.Text.ForEach(x => x.SentenceElements.ForEach(x => x.Symbols.ForEach(x => streamWriter.Write(x.Character))));
                }
            }
           
        }
        
        private void WriteListString(List<string> text, string filePath)
        {
            if (text!=null)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    text.ForEach(x => streamWriter.WriteLine(x));
                }
            }
            
        }

        private void WriteISentenceElement(List<ISentenceElement> sentenceElements, string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                foreach (var sentenceElement in sentenceElements)
                {
                    streamWriter.WriteLine();
                    sentenceElement.Symbols.ForEach(x => streamWriter.Write(x.Character));
                }
            }
        }

        private void WriteListISentenceText(List<ISentence> text, string filePath)
        {
            if (text != null)
            {
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach (var sentence in text)
                    {
                        streamWriter.WriteLine();
                        sentence.SentenceElements.ForEach(x => x.Symbols.ForEach(x => streamWriter.Write(x.Character)));
                    }
                }
            }
        }



    }
}
