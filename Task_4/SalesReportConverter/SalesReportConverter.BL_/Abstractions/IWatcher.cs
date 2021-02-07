﻿using System;

namespace SalesReportConverter.BL_.Abstractions
{
    public interface IWatcher : IDisposable
    {
        event EventHandler<string> ThereIsFileToHandlingEvent;
        event EventHandler<string> MessageHandlerEvent;
        void Watch();
        void StopWatch();       
    }
}
