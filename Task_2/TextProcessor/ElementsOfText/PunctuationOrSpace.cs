using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public class PunctuationOrSpace : ISentenceElement
    {
        public PunctuationOrSpace(Symbol punctuationOrSpace)
        {
            symbols = new List<Symbol>();
            symbols.Add(punctuationOrSpace);
        }
        public List<Symbol> symbols { get; set; }
        
       //public int IndexInSentence { get; set; }
    }
}