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
       
        private string patternSentence = @"([A-Za-z\d\\s“]+[^.!?]*[”.?!\n]+)"; 
        public List<string> TextParserBySubSentence(string text)
        {
            if (text!=null)
            {
                var SplitTextSubSentence = new Regex(patternSentence).Split(text).ToList();
                return SplitTextSubSentence;
            }
            return null;           
        }


        public List<ISymbol> TextParserSentenceBySymbols(string sentence)
        {
            List<ISymbol> CollectionSymbolFromText = new List<ISymbol>();
            for (int i = 0; i < sentence.Length; i++)
            {                
                CollectionSymbolFromText.Add(new Symbol { Character = sentence[i]});
            }
            return CollectionSymbolFromText;
        }


        public List<ISentenceElement> SentenceOfSybolsParserBySentenceElement(List<ISymbol> sentence)
        {
            List<ISentenceElement> sentenceElements = new List<ISentenceElement>();
            List<ISymbol> bufferLetters = new List<ISymbol>();
            foreach (var symbol in sentence)
            {
                if (Regex.IsMatch(symbol.Character.ToString(), "[a-zA-Z]"))
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