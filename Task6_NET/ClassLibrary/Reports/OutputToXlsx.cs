using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace ClassLibrary.Reports
{
    public static class OutputToXlsx
    {
        public static void ToXlsxFile(IReport report, string directory = @"..\..\", string fileName = "Report")
        {
            string fileFormat = ".xlsx";

            string outputPath = directory + fileName + fileFormat;

            bool exceptionFlag = false;

            if (!Directory.Exists(directory))
            {
                throw new ArgumentException("The directory does not exist");
            }

            Application xlApplication = new Application();
            Workbook xlWorkbook = xlApplication.Workbooks.Add();

            foreach (IEnumerable<IEnumerable<string>> sheet in report.GetReportTables())
            {
                int i = 1;
                Worksheet xlSheet = (Worksheet)xlWorkbook.Sheets[i];

                try
                {
                    IEnumerable<string> header = report.GetReportHeader();

                    bool writeHeaderFlag = true;
                    int row = 1;
                    int col = 1;

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

                    Range dataTable = xlSheet.get_Range(xlSheet.Cells[1, 1], xlSheet.Cells[100, 100]);
                    dataTable.Columns.AutoFit();

                    Range dataHeader = xlSheet.get_Range(xlSheet.Cells[1, 1], xlSheet.Cells[1, 50]);
                    dataHeader.Cells.Font.Bold = true;
                }
                catch (Exception exception)
                {
                    exceptionFlag = true;
                    throw new Exception(exception.Message);
                }

                i++;
            }

            if (exceptionFlag == false)
            {
                xlWorkbook.SaveAs(outputPath);
                xlWorkbook.Close(true);
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
