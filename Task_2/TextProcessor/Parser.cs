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
        private string patternSartWord= @"(\b[^\s\n]*\b)";
        private string patternSentence = @"([A-Za-z\d\\s]+[^.!?]*[.?!\n])";
       
        private List<Word> CollectionWordFromText;        
        private SeparatorContainer separator = new SeparatorContainer();
        List<Symbol> word = new List<Symbol>();


        public List<Sentence> TextParserBySentence(string text)
        {
            List<Sentence> CollectionSentence = new List<Sentence>();
            string[] SplitTextSentence = new Regex(patternSentence).Split(text);
            for (int i = 0; i < SplitTextSentence.Count()-1; i++)
            {
                CollectionSentence.Add(
                new Sentence { index = i, sentence = SplitTextSentence[i] }
                );
            }
            return CollectionSentence;
        }
        public List<Symbol> TextParserSentenceBySymbols(Sentence sentence)
        {
            List<Symbol> CollectionSymbolFromText = new List<Symbol>();

            for (int i = 0; i < sentence.sentence.Length; i++)
            {
                CollectionSymbolFromText.Add(new Symbol { character = sentence.sentence[i], indexInSentence = i });
            }
            return CollectionSymbolFromText;
        }

        

        public List<ISentenceElement> TextParserBySentenceElement(List<Symbol> sentence)
        {
            List<ISentenceElement> sentenceElements = new List<ISentenceElement>();
            List<Symbol> bufferLetters=new List<Symbol>();            
            int counter = 0;
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
                        sentenceElements.Add(new Word() { symbols = bufferLetters, IndexInSentence = counter });
                        bufferLetters.Clear();
                        counter++;
                    }

                    sentenceElements.Add(new PunctuationOrSpace
                    {
                        symbol = symbol,
                        IndexInSentence = counter
                    });
                    counter++;
                }                
            }
            return sentenceElements;
        }

       


        
        public void TextParserByWords(List<Symbol> CollectionSymbolFromText)
        {
            
                foreach (var symbol in CollectionSymbolFromText)
                {               

                if (separator.WordSeparators().Contains(symbol.character.ToString()))
                {

                }

                }              
            

        }



    }
}