using System;
using System.Collections.Generic;

namespace ConsoleApp.Reports
{
    public interface IReport
    {
        IEnumerable<string> GetReportHeader();

        IEnumerable<IEnumerable<string>> GetReportTable();
    }
}
