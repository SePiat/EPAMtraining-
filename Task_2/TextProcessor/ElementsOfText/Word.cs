using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessor
{
    public class Word : ISentenceElement
    {
      

        public List<Symbol> symbols { get; set; }
        public int IndexInSentence { get; set; }

          
    }
}