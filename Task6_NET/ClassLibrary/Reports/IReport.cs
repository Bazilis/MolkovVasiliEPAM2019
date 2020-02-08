using System;
using System.Collections.Generic;

namespace ClassLibrary.Reports
{
    /// <summary>
    /// Defines methods for export data to report
    /// </summary>
    public interface IReport
    {
        IEnumerable<string> GetReportHeader();

        IEnumerable<IEnumerable<IEnumerable<string>>> GetReportTables();
    }
}
