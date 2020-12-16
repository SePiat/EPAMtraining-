using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public interface ISentenceElement
    {
        List<ISymbol> Symbols { get; set; }        
    }
}