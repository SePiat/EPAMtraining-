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
            catch
            {
                throw new Exception($"Error in method WriteWordsSetLengthByQuestionableSentences()");
            }
        }

        public void WriteSentencesOrderByTheNumberOfWords(List<ISentence> text)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("SentencesOrderByTheNumberOfWords");
                WriteListISentenceText(text, filePath);
            }
            catch
            {
                throw new Exception ("Error in method file WriteSentencesOrderByTheNumberOfWords()");
            }
        }


        public void WriteQuestionableSentences(List<ISentence> text)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("QuestionableSentences");
                WriteListISentenceText(text, filePath);
            }
            catch
            {
                throw new Exception("Error in method file WriteQuestionableSentences()");
            }
        }

        public void WriteWordsSetLengthByQuestionableSentences(List<ISentenceElement> words)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("WordsSetLengthByQuestionableSentences");
                WriteISentenceElement(words, filePath);
            }
            catch
            {
                throw new Exception("Error in method WriteWordsSetLengthByQuestionableSentences()");
            }
        }


        public void WriteTextModel(ITextModel textModel)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("TextModel");
                WriteTextModel(textModel, filePath);
            }
            catch
            {
                throw new Exception("Error in method WriteTextModel()");
            }
        }
        public void WriteTextModelWithoutWordsOfSetLengthWithСonsonantLetter(ITextModel textModel)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("TextModelWithoutWordsOfSetLengthWithСonsonantLetter");
                WriteTextModel(textModel,  filePath);
            }
            catch
            {
                throw new Exception("Error in method WriteTextModelWithoutWordsOfSetLengthWithСonsonantLetter()");
            }
        }

        public void WriteTextModelExchangeWordOfSetLengthWhithString(ITextModel textModel)
        {
            try
            {
                string filePath = ConfigurationManager.AppSettings.Get("TextModelExchangeWordOfSetLengthWhithString");
                WriteTextModel(textModel, filePath);
            }
            catch
            {
                throw new Exception("Error in method WriteTextModelExchangeWordOfSetLengthWhithString()");
            }
        }




        private void WriteTextModel(ITextModel textModel, string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                textModel.Text.ForEach(x => x.SentenceElements.ForEach(x => x.Symbols.ForEach(x => streamWriter.Write(x.Character))));                
            }
        }

        private void WriteString(string text, string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.Write(text);
            }
        }
        private void WriteListString(List<string> text, string filePath)
        {
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                text.ForEach(x => streamWriter.WriteLine(x));
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
