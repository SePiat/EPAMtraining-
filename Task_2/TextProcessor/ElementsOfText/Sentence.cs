using System.Collections.Generic;

namespace TextProcessor
{
    public class Sentence:ISentence
    {
        public List<ISentenceElement> SentenceElements { get; set; } = new List<ISentenceElement>();
       // public int index { get; private set; }
        public Sentence(List<ISentenceElement> sentence)
        {
            SentenceElements.AddRange(sentence);           
        }
        public Sentence(ISentenceElement sentence)
        {
            SentenceElements.Add(sentence);
        }
    }
}