using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessor
{
    public class Word : ISentenceElement
    {
        public Word(List<ISymbol> word)
        {          
            Symbols.AddRange(word);
            word.ForEach(x => stringWord += x.Character);
        }
        public List<ISymbol> Symbols { get; set; } = new List<ISymbol>();       
        public string stringWord;
    }
}