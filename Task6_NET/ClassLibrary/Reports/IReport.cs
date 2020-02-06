using System;
using System.Collections.Generic;

namespace ClassLibrary.Reports
{
    public interface IReport
    {
        IEnumerable<string> GetReportHeader();

        IEnumerable<IEnumerable<IEnumerable<string>>> GetReportTables();
    }
}
