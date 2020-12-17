using System.Collections.Generic;

namespace TextProcessor.ReaderWriter
{
    public interface IWriterText
    {
        void WriteStringText(string text, string fileName);
        void WriteListStringText(List<string> text, string fileName);
        void WriteListISentenceText(List<ISentence> text, string fileName);
    }
}