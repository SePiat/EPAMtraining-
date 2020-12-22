
using System.Collections.Generic;

namespace TextProcessor.Core
{
    public interface IParser
    {
        //первый метод метод
       /* List<string> TextParserBySubSentence(string text);
        List<ISymbol> TextParserSentenceBySymbols(string sentence);
        List<ISentenceElement> SentenceOfSybolsParserBySentenceElement(List<ISymbol> sentence);
        ISentence GetSentenceByISentenceElemtnt(List<ISentenceElement> sentenceElements);*/

        //второй метод
        List<ISymbol> ParserTextBySymbols(string sentence);
        List<ISentenceElement> CollectionSymbolFromTextParserBySentenceElement(List<ISymbol> CollectionSymbolFromText);
        List<ISymbol> CollectionSymbolFromText { get; set; }
        List<ISentence> GetColletionSentencesByISentenceElemtnts(List<ISentenceElement> sentenceElements);
    }
}