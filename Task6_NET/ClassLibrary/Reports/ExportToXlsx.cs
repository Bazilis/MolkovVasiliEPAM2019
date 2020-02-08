using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace ClassLibrary.Reports
{
    /// <summary>
    /// Export report to Excel file (*.xlsx)
    /// </summary>
    public static class ExportToXlsx
    {
        public static void ToXlsxFile(IReport report, string directory, string fileName = "Report")
        {
            string fileFormat = ".xlsx";

            string outputPath = directory + fileName + fileFormat;

            bool exceptionFlag = false;

            bool writeHeaderFlag = true;

            int row = 1;
            int col = 1;

            IEnumerable<string> header = report.GetReportHeader();

            Application xlApplication = new Application();
            Workbook xlWorkbook = xlApplication.Workbooks.Add();
            Worksheet xlSheet = (Worksheet)xlWorkbook.Sheets[1];

            foreach (IEnumerable<IEnumerable<string>> sheet in report.GetReportTables())
            {
                try
                {
                    foreach (IEnumerable<string> rowStrings in sheet)
                    {
                        if (writeHeaderFlag)
                        {
                            foreach (string columnName in header)
                            {
                                xlSheet.Cells[row, col] = columnName;
                                col++;
                            }
                            writeHeaderFlag = false;
                            row++;
                            col = 1;
                        }

                        foreach (string cellValue in rowStrings)
                        {
                            xlSheet.Cells[row, col] = cellValue;
                            col++;
                        }
                        row++;
                        col = 1;
                    }

                    Range dataTable = xlSheet.Range[xlSheet.Cells[1, 1], xlSheet.Cells[100, 100]];
                    dataTable.Columns.AutoFit();

                    Range dataHeader = xlSheet.Range[xlSheet.Cells[1, 1], xlSheet.Cells[1, 50]];
                    dataHeader.Cells.Font.Bold = true;
                }
                catch (Exception exception)
                {
                    exceptionFlag = true;
                    throw new Exception(exception.Message);
                }
            }

            if (exceptionFlag == false)
            {
                xlWorkbook.SaveAs(outputPath);
                xlWorkbook.Close();
                xlApplication.Quit();
            }
            else
            {
                xlWorkbook.Close();
                xlApplication.Quit();
            }
        }
    }
}
