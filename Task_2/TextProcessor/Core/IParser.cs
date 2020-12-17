
using System.Collections.Generic;

namespace TextProcessor.Core
{
    public interface IParser
    {
        List<string> TextParserBySubSentence(string text);
        List<ISymbol> TextParserSentenceBySymbols(string sentence);
        List<ISentenceElement> SentenceOfSybolsParserBySentenceElement(List<ISymbol> sentence);
        ISentence GetSentenceByISentenceElemtnt(List<ISentenceElement> sentenceElements);
    }
}