using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessor
{

    public static class TextСleaner
    {        
        private static bool isPreviousSenteceElementlSpaceOrTab = false;        
        private static Dictionary<int, List<int>> sentenceElementsToRemove = new Dictionary<int, List<int>>();// словарь с номером предложения и номерами элементов предложения подлежащих удалению
        private static int counter;
      
        public static void CleanText(ITextModel textModel)
        {
            foreach (var setence in textModel.Text)
            {
                foreach (var sentenceElement in setence.SentenceElements)
                {
                    if (sentenceElement.Symbols.Count() == 1 && sentenceElement.Symbols[0].Character == " " || sentenceElement.Symbols[0].Character == "\t")
                    {
                        //сохраняем номер предложения, номер элемента в предложении подлежащий для удалению
                        if (isPreviousSenteceElementlSpaceOrTab) 
                        {
                            if (sentenceElementsToRemove.ContainsKey(textModel.Text.IndexOf(setence)))
                            {                                
                                sentenceElementsToRemove[textModel.Text.IndexOf(setence)].Add(setence.SentenceElements.IndexOf(sentenceElement));
                            }
                            else
                            {
                                sentenceElementsToRemove.Add(textModel.Text.IndexOf(setence), new List<int> { setence.SentenceElements.IndexOf(sentenceElement) });
                            }
                        }
                        isPreviousSenteceElementlSpaceOrTab = true;
                    }
                    else
                    {
                        isPreviousSenteceElementlSpaceOrTab = false;
                    }
                }
            }

            //удаляем повторяющиеся элементы
            foreach (var item in sentenceElementsToRemove)
            {
                foreach (var indexSentenceElement in item.Value)
                {
                    textModel.Text[item.Key].SentenceElements.RemoveAt(indexSentenceElement-counter);
                    counter++;
                }
                counter = 0;
            }
            sentenceElementsToRemove.Clear();


            //заменяем одиночные TAB на пробел  

            foreach (var setence in textModel.Text)
            {
                foreach (var sentenceElement in setence.SentenceElements)
                {
                    if (sentenceElement.Symbols.Count() == 1 && sentenceElement.Symbols[0].Character == "\t")
                    {
                        if (sentenceElementsToRemove.ContainsKey(textModel.Text.IndexOf(setence)))
                        {
                            sentenceElementsToRemove[textModel.Text.IndexOf(setence)].Add(setence.SentenceElements.IndexOf(sentenceElement));
                        }
                        else
                        {
                            sentenceElementsToRemove.Add(textModel.Text.IndexOf(setence), new List<int> { setence.SentenceElements.IndexOf(sentenceElement) });
                        }
                    }
                }
            }            
            foreach (var item in sentenceElementsToRemove)
            {
                foreach (var indexSentenceElement in item.Value)
                {
                    textModel.Text[item.Key].SentenceElements[indexSentenceElement].Symbols[0].Character.Remove(0);
                    textModel.Text[item.Key].SentenceElements[indexSentenceElement].Symbols[0].Character= " ";                    
                }
            } 
        }
    }

    //первый вариант

    /*private static string pattern1 = @"(\r\n)+";
    private static string pattern2 = @"( {2,})";
    private static string pattern3 = @"(\t)+";
    public static string CleanText(string text)
    {
        string cleanedText1 = Regex.Replace(text, pattern1, "\r\n"); //удаляет множественные переносы строки
        cleanedText2 = Regex.Replace(cleanedText1, pattern2, " "); //удаляет множественные пробелы
        cleanedText = Regex.Replace(cleanedText2, pattern3, " "); //удаляет множественные пробелы
        return cleanedText;
    }*/
}
