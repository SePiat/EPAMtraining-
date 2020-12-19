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
            stringPunctuationOrSpace = punctuationOrSpace.Character.ToString();
        }
        public List<ISymbol> Symbols { get; set; }= new List<ISymbol>();
        public string stringPunctuationOrSpace;


    }
}