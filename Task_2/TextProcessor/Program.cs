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
            
            writer.WriteTextModel(performer.TextModel);
            TextСleaner.CleanText(performer.TextModel);//Фильтр, заменяющий множественные пробелы и табуляции одним пробелом

            var result = performer.SentencesOrderByTheNumberOfWords(performer.TextModel); //Предложения заданного текста в порядке возрастания количества слов в каждом из них.
            writer.WriteSentencesOrderByTheNumberOfWords(result);

            var result2 = performer.WordsSetLengthByQuestionableSentences(performer.TextModel);// Слова заданной длины из вопросительных предложений
            writer.WriteWordsSetLengthByQuestionableSentences(result2);

            performer.TextModelWithoutWordsOfSetLengthWithСonsonantLetter(performer.TextModel); // Удаляет из текста слова заданной длины, начинающиеся на согласную
            writer.WriteTextModelWithoutWordsOfSetLengthWithСonsonantLetter(performer.TextModel);

            performer.TextModelExchangeWordOfSetLengthWhithString(performer.TextModel);//В указанном предложении слова указанной длины заменяет указанной строкой
            writer.WriteTextModelExchangeWordOfSetLengthWhithString(performer.TextModel);

            Console.ReadKey();
        }
    }
}
