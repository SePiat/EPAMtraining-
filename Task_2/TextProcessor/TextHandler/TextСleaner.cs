using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    public static class TextСleaner
    {
        /*private static string pattern1 = @"(\r\n)+";
        private static string pattern2 = @"( {2,})";
        public static string CleanText(string text)
        {
            string cleanedText = Regex.Replace(text, pattern1, "\r\n"); //удаляет множественные переносы строки
            cleanedText = Regex.Replace(cleanedText, pattern2, " "); //удаляет множественные пробелы
            return cleanedText;
        }*/
        private static int counter;
        private static int counter2;
        private static int counter3;
        private static List<int> buffer = new List<int>();
        public static void CleanText(ITextModel textModel)
        {            
            foreach (var setence in textModel.Text)
            {
                if (setence.SentenceElements.Count() == 1 && setence.SentenceElements.Where(x => x.Symbols.Where(x => x.Character == "\r\n").Count() > 0).Count() > 0)//выбераем предлжение длиной в один символ и символом равном переносу строки
                {
                    counter++;
                    if (counter > 1)
                    {
                        buffer.Add(textModel.Text.IndexOf(setence));
                    }
                }
                else 
                {
                    counter = 0;
                }
               
            }
            foreach (var indexSentens in buffer)
            {             
                textModel.Text.RemoveAt(indexSentens- counter2);
                counter2++;
            }
            counter2 = 0;
            buffer.Clear();           
        }

        /*private static void CleanSentence(ISentence sentence)
        {
            
            foreach (var sentenceElement in sentence.SentenceElements)
            {
                foreach (var symbol in sentenceElement.Symbols)
                {
                    counter3++;
                    if (counter > 1)
                    {
                        buffer.Add(textModel.Text.IndexOf(setence));
                    }
                    else
                    {
                        counter = 0;
                    }
                }

               
                
            }
        }*/
    }
}
