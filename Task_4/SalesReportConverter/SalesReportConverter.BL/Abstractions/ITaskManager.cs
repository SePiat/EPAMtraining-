using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SalesReportConverter.BL.Abstractions
{
    public interface ITaskManager
    {
        void CreateTask(object sender, string fileName);

    }
}
