﻿using System;
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
        public List<ISymbol> CollectionSymbolFromText { get; set; } = new List<ISymbol>();
        public List<ISymbol> ParserLineTextBySymbols(string line)
        {
            if (line!=null)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    CollectionSymbolFromText.Add(new Symbol { Character = line[i].ToString() });
                }
                if (CollectionSymbolFromText[CollectionSymbolFromText.Count() - 1].Character != "\r\n")//фильтр на множественные переносы строк
                {
                    CollectionSymbolFromText.Add(new Symbol { Character = "\r\n" });
                }
            }
            return CollectionSymbolFromText;
        }

        public List<ISentenceElement> CollectionSymbolFromTextParserBySentenceElement(List<ISymbol> CollectionSymbolFromText)
        {
            List<ISentenceElement> sentenceElements = new List<ISentenceElement>();
            List<ISymbol> bufferLetters = new List<ISymbol>();
            if (CollectionSymbolFromText!=null)
            {
                foreach (var symbol in CollectionSymbolFromText)
                {
                    if (Regex.IsMatch(symbol.Character.ToString(), @"[’a-zA-Z\dа-яА-Я]"))
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
            }
            
            return sentenceElements;
        }

        public List<ISentence> GetColletionSentencesByISentenceElemtnts(List<ISentenceElement> sentenceElements)
        {
            List<ISentence> sentences = new List<ISentence>();
            List<ISentenceElement> buffer = new List<ISentenceElement>();
            bool santenceFlag = false;
            if (sentenceElements!=null)
            {
                foreach (var sentenceElement in sentenceElements)
                {
                    if (santenceFlag || sentenceElement is Word/*Regex.IsMatch(sentenceElement.Symbols[0].Character.ToString(), @"[A-Z\dА-Я]")*/)
                    {
                        santenceFlag = true;
                        buffer.Add(sentenceElement);
                        if (Regex.IsMatch(sentenceElement.Symbols[0].Character.ToString(), @"[.?!]"))
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
            }
            
            return sentences;
        }

        public List<ISymbol> ParserInputTextBySymbols(string inputString)
        {
            if (inputString!=null)
            {
                CollectionSymbolFromText.Clear();
                for (int i = 0; i < inputString.Length; i++)
                {
                    CollectionSymbolFromText.Add(new Symbol { Character = inputString[i].ToString() });
                }
            }
           
            return CollectionSymbolFromText;
        }






        //Первый вариант/////////////////////////////////////////////////////////////////////////        
        /* private string patternSentence = @"([A-Za-z\d]+[^.!?]*[.?!\n]+)"; 
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