
using System.Collections.Generic;

namespace TextProcessor.Core
{
    public interface IParser
    {           
        List<ISymbol> ParserLineTextBySymbols(string sentence);
        List<ISymbol> ParserInputTextBySymbols(string inputString);
        List<ISentenceElement> CollectionSymbolFromTextParserBySentenceElement(List<ISymbol> CollectionSymbolFromText);
        List<ISymbol> CollectionSymbolFromText { get; set; }
        List<ISentence> GetColletionSentencesByISentenceElemtnts(List<ISentenceElement> sentenceElements);
    }
}