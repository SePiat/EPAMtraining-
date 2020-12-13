using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor
{
    public interface ISentenceElement
    {
        char[] Characters { get; set; }
        int IndexInSentence { get; set; }
    }
}