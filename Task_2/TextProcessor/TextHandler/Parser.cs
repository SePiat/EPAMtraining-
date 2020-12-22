using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextProcessor.Core;

namespace TextProcessor
{
    public class Parser : IParser
    {

        //Второй метод/////////////////////////////////////////////////////////////////////////
        public List<ISymbol> CollectionSymbolFromText { get; set; } = new List<ISymbol>();
        public List<ISymbol> ParserTextBySymbols(string sentence)
        {
            if (sentence.Count()<=1)
            {

            }
            for (int i = 0; i < sentence.Length; i++)
            {
                var x = sentence[i];
                CollectionSymbolFromText.Add(new Symbol { Character = sentence[i] });
            }
            return CollectionSymbolFromText;
        }

       
        public List<ISentenceElement> CollectionSymbolFromTextParserBySentenceElement(List<ISymbol> CollectionSymbolFromText)
        {
            List<ISentenceElement> sentenceElements = new List<ISentenceElement>();
            List<ISymbol> bufferLetters = new List<ISymbol>();
            foreach (var symbol in CollectionSymbolFromText)
            {             
                if (Regex.IsMatch(symbol.Character.ToString(), @"['a-zA-Z\dа-яА-Я]"))
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

        public List<ISentence> GetColletionSentencesByISentenceElemtnts(List<ISentenceElement> sentenceElements)
        {
            List<ISentence> sentences = new List<ISentence>();
            List<ISentenceElement> buffer = new List<ISentenceElement>();
            bool santenceFlag = false;
            foreach (var sentenceElement in sentenceElements)
            {
                if (santenceFlag || Regex.IsMatch(sentenceElement.Symbols[0].Character.ToString(), @"[A-Z\dА-Я]"))
                {
                    santenceFlag = true;
                    buffer.Add(sentenceElement);
                    if (Regex.IsMatch(sentenceElement.Symbols[0].Character.ToString(), @"[.?!\n]"))
                    {                       
                        sentences.Add(new Sentence(buffer));
                        buffer.Clear();
                        santenceFlag = false;
                    }
                }
                else
                {
                    sentences.Add(new Sentence(sentenceElement));
                }                           
            }
            return sentences;
        }






        //Первый метод/////////////////////////////////////////////////////////////////////////        
       /* private string patternSentence = @"([A-Za-z\d\\s]+[^.!?]*[.?!\n]+)"; //без ковычек
        public List<string> TextParserBySubSentence(string text)
        {
            if (text != null)
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
                CollectionSymbolFromText.Add(new Symbol { Character = sentence[i] });
            }
            return CollectionSymbolFromText;
        }


        public List<ISentenceElement> SentenceOfSybolsParserBySentenceElement(List<ISymbol> sentence)
        {
            List<ISentenceElement> sentenceElements = new List<ISentenceElement>();
            List<ISymbol> bufferLetters = new List<ISymbol>();
            foreach (var symbol in sentence)
            {
                if (Regex.IsMatch(symbol.Character.ToString(), @"[a-zA-Z\dа-яА-Я]"))
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
        public ISentence GetSentenceByISentenceElemtnt(List<ISentenceElement> sentenceElements)
        {
            ISentence sentence = new Sentence(sentenceElements);
            return sentence;
        }*/









    }
}