using System.Collections.Generic;

namespace TextProcessor
{
    public class Sentence
    {
        public List<ISentenceElement> sentence { get;private set; }
       // public int index { get; private set; }
        public Sentence(List<ISentenceElement> sentence)
        {
            this.sentence = sentence;           
        }
    }
}