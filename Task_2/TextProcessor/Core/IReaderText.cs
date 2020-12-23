using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor.Core
{
    public interface IReaderText
    {
        //string ReadTextAll();
        void ReadTextString(IParser parser);
    }
}
