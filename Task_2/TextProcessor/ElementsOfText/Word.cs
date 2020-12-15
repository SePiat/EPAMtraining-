using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessor
{
    public class Word : ISentenceElement
    {
        public Word(List<Symbol> word)
        {
            symbols = new List<Symbol>();
            symbols.AddRange(word);
        }
        public List<Symbol> symbols { get; set; }
        //public int IndexInSentence { get; set; }
    }
}