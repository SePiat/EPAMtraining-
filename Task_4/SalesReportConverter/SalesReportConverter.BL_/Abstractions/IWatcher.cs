using System;

namespace SalesReportConverter.BL.Abstractions
{
    public interface IWatcher
    {
        event EventHandler<string> ThereIsFileToHandlingEvent;
        event EventHandler<string> MessageHandlerEvent;
        void Watch();
        void StopWatch();
        void Dispose();
    }
}
