using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Reports
{
    public interface IReport
    {
        IEnumerable<string> GetReportHeader();

        IEnumerable<IEnumerable<IEnumerable<string>>> GetReportTables();
    }
}
