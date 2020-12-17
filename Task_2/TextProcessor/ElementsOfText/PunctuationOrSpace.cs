using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public class PunctuationOrSpace : ISentenceElement
    {
        public PunctuationOrSpace(ISymbol punctuationOrSpace)
        {            
            Symbols.Add(punctuationOrSpace);
        }
        public List<ISymbol> Symbols { get; set; }= new List<ISymbol>();
        
    }
}