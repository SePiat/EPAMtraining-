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
            var result= performer.SentencesOrderByTheNumberOfWords(performer.textModel);
            writer.WriteListISentenceText(result, "ListString");
            Console.WriteLine();
        }
    }
}
