using System.Collections.Generic;

namespace TextProcessor.TextHandler
{
    public interface IPerformer
    {
        public ITextModelCreator Creator { get; set; }
        public ITextModel TextModel { get; set; }
        void Perform();
        List<ISentence> SentencesOrderByTheNumberOfWords(ITextModel textModel);
        List<string> WordsSetLengthByQuestionableSentence(ITextModel textModel);

    }
}