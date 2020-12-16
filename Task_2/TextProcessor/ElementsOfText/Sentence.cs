using System.Collections.Generic;

namespace TextProcessor
{
    public class Sentence:ISentence
    {
        public List<ISentenceElement> SentenceElements { get; set; }
       // public int index { get; private set; }
        public Sentence(List<ISentenceElement> sentence)
        {
            this.SentenceElements = sentence;           
        }
    }
}