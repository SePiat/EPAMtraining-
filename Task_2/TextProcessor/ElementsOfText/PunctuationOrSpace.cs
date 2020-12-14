using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public class PunctuationOrSpace : ISentenceElement
    {
        public Symbol symbol;
        public List<Symbol> symbols { get; set; }
        public int IndexInSentence { get; set; }
    }
}