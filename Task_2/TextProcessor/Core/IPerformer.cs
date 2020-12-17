using System.Collections.Generic;

namespace TextProcessor.TextHandler
{
    public interface IPerformer
    {
        public ITextModelCreator creator { get; set; }
        public ITextModel textModel { get; set; }
        void Perform();
        List<ISentence> SentencesOrderByTheNumberOfWords(ITextModel textModel);

    }
}