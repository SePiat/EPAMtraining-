using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TextProcessor
{
    public class SeparatorContainer
    {
        private string[] sentenceSeparators = new string[] { "?", "!", ".", "...", "?!" };
        private string[] wordSeparators = new string[] { " ", "?", "!", ".", ",", "...", "?!", "?", "!", ".", ",", "...", "?!", };

        public IEnumerable<string> SentenceSeparators()
        {
            return sentenceSeparators.AsEnumerable();
        }
        
        public string[] WordSeparators()
        {            
            return wordSeparators;
        }

        public IEnumerable<string> All()
        {
            return sentenceSeparators.Concat(WordSeparators());
        }
    }
}
