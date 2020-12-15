using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TextProcessor
{
    public class Parser
    {     
       
        private string patternSentence = @"([A-Za-z\d\\s]+[^.!?]*[.?!\n])";      
        


        public List<string> TextParserBySubSentence(string text)
        {            
            var SplitTextSubSentence = new Regex(patternSentence).Split(text).ToList();           
            return SplitTextSubSentence;
        }


        public List<Symbol> TextParserSentenceBySymbols(string sentence)
        {
            List<Symbol> CollectionSymbolFromText = new List<Symbol>();
            for (int i = 0; i < sentence.Length; i++)
            {
                char x = sentence[i];
                CollectionSymbolFromText.Add(new Symbol { character = sentence[i], indexInSentence = i });
            }
            return CollectionSymbolFromText;
        }


        public List<ISentenceElement> SentenceOfSybolsParserBySentenceElement(List<Symbol> sentence)
        {
            List<ISentenceElement> sentenceElements = new List<ISentenceElement>();
            List<Symbol> bufferLetters = new List<Symbol>();
            foreach (var symbol in sentence)
            {
                if (Regex.IsMatch(symbol.character.ToString(), "[a-zA-Z]"))
                {
                    bufferLetters.Add(symbol);
                }
                else
                {
                    if (bufferLetters.Count() > 0)
                    {
                        sentenceElements.Add(new Word(bufferLetters));
                        bufferLetters.Clear();
                    }
                    sentenceElements.Add(new PunctuationOrSpace(symbol));
                }
            }
            return sentenceElements;
        }
        public Sentence GetSentenceByISentenceElemtnt(List<ISentenceElement> sentenceElements)
        {
            Sentence sentence = new Sentence(sentenceElements);
            return sentence;
        }





        



    }
}