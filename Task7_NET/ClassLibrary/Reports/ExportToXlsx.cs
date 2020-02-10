using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;


namespace ConsoleApp.Reports
{
    public static class Unloader
    {
        public static void ExportToXlsx(IReport report, string directory, string fileName = "Report")
        {
            string fileFormat = ".xlsx";

            string outputPath = directory + fileName + fileFormat;

            bool exceptionFlag = false;


            Application xlApplication = new Application();
            Workbook xlWorkbook = xlApplication.Workbooks.Add();
            Worksheet xlSheet = (Worksheet)xlWorkbook.Sheets[1];

            try
            {
                IEnumerable<string> header = report.GetReportHeader();

                int row = 1;
                int col = 1;
                bool headerFlag = false;

                foreach (IEnumerable<string> rowStrings in report.GetReportTable())
                {
                    if (headerFlag == false)
                    {
                        foreach (string columnName in header)
                        {
                            xlSheet.Cells[row, col] = columnName;
                            col++;
                        }
                        headerFlag = true;
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


                Range dataBody = xlSheet.Range[xlSheet.Cells[1, 1], xlSheet.Cells[100, 100]];
                dataBody.Columns.AutoFit();
                Range dataHeader = xlSheet.Range[xlSheet.Cells[1, 1], xlSheet.Cells[1, 50]];
                dataHeader.Cells.Font.Bold = true;
            }
            catch (Exception exception)
            {
                exceptionFlag = true;
                throw new Exception(exception.Message);
            }
            finally
            {
                if (exceptionFlag == false)
                {
                    xlWorkbook.SaveAs(outputPath);
                    xlWorkbook.Close();
                    xlApplication.Quit();
                }
                else
                {
                    xlApplication.Quit();
                }
            }
        }
    }
}
