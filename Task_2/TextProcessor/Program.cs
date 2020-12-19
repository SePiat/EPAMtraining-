using System;
using System.Collections.Generic;
using TextProcessor.ReaderWriter;
using TextProcessor.TextHandler;

namespace TextProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            IPerformer performer = new Performer();
            IWriterText writer = new WriterText();

            performer.Perform();
            var result= performer.SentencesOrderByTheNumberOfWords(performer.TextModel);
            writer.WriteListISentenceText(result);
            var result2 = performer.WordsSetLengthByQuestionableSentence(performer.TextModel);
            writer.WriteWordsSetLengthByQuestionableSentence(result2);

            Console.WriteLine();
        }
    }
}
