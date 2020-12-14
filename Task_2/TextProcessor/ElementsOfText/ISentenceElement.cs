using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public interface ISentenceElement
    {
        List<Symbol> symbols { get; set; }
        int IndexInSentence { get; set; }
    }
}