using System.Collections.Generic;

namespace TextProcessor.ReaderWriter
{
    public interface IWriterText
    {
        void WriteQuestionableSentences(List<ISentence> text);
        void WriteWordsSetLengthByQuestionableSentences(List<string> text);
        void WriteSentencesOrderByTheNumberOfWords(List<ISentence> text);
        void WriteTextModelWithoutWordsOfSetLengthWithСonsonantLetter(ITextModel textModel);
        void WriteTextModel(ITextModel textModel);
    }
}