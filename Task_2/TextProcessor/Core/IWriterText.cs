using System.Collections.Generic;

namespace TextProcessor.ReaderWriter
{
    public interface IWriterText
    {
        void WriteStringText(string text);
        void WriteWordsSetLengthByQuestionableSentence(List<string> text);
        void WriteListISentenceText(List<ISentence> text);
    }
}