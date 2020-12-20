using System.Collections.Generic;

namespace TextProcessor.TextHandler
{
    public interface IPerformer
    {
         ITextModelCreator Creator { get; set; }
        ITextModel TextModel { get; set; }
        void Perform();
        List<ISentence> SentencesOrderByTheNumberOfWords(ITextModel textModel);
        List<string> WordsSetLengthByQuestionableSentences(ITextModel textModel);
        void TextModelWithoutWordsOfSetLengthWithСonsonantLetter(ITextModel textModel);
        void TextModelExchangeWordOfSetLengthWhithString(ITextModel textModel);

    }
}