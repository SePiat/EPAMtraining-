using System;
using System.Collections.Generic;
using System.Text;

namespace TextProcessor.Core
{
    public interface IReaderText
    {       
        void ReadTextString(IParser parser);
    }
}
