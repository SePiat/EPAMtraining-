using System.Collections.Generic;

namespace TextProcessor
{
    public interface ISentence
    {
         List<ISentenceElement> SentenceElements { get; set; }
    }
}