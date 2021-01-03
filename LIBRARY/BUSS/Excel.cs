
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace LIBRARY.BUSS
{
    class ExcelExport
    {
        public void Export(System.Data.DataTable table, string tit, object[] columnHeader, string fileName)
        {

            int columnCount = table.Columns.Count;
            Excel.Application xlApp = new Excel.Application();
            if (xlApp == null)
            {
                throw new Exception("Can't use the excel library");

            }
            xlApp.Visible = false;

            object misValue = System.Reflection.Missing.Value;

            Workbook wb = xlApp.Workbooks.Add(misValue);

            Worksheet ws = (Worksheet)wb.Worksheets[1];

            if (ws == null)
            {
                throw new Exception("Can't create worksheet");
            }

            Range range = ws.get_Range((Range)(ws.Cells[1, 1]), (Range)(ws.Cells[1, columnCount]));
            range.MergeCells = true;
            range.Value2 = "VIETNAM NATIONAL UNIVERSITY HOCHIMINH CITY";
            range.Font.Bold = true;
            range.Font.Color = Color.Blue;
            range.Font.Size = "12";

            Range range1 = ws.get_Range((Range)(ws.Cells[2, 1]), (Range)(ws.Cells[2, columnCount]));
            range1.MergeCells = true;
            range1.Value2 = "INFORMATION TECHNOLOGY OF UNIVERSITY"; 
            range1.Font.Bold = true;
            range1.Font.Color = Color.Blue;
            range1.Font.Size = "12";

            Range title = ws.get_Range((Range)(ws.Cells[4, 1]), (Range)(ws.Cells[4, columnCount]));
            title.MergeCells = true;
            title.Value2 = tit;
            title.Font.Bold = true;
            title.Font.Size = "18";
            title.HorizontalAlignment = XlHAlign.xlHAlignCenter;


            Excel.Range headerRange = ws.get_Range((Range)(ws.Cells[5, 1]), (Range)(ws.Cells[5, columnCount]));
            headerRange.Value2 = columnHeader;
            headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            headerRange.Font.Bold = true;

            int rowCount = table.Rows.Count;
            object[,] cell = new object[rowCount, columnCount];

            for (int i = 0; i < rowCount; i++)
                for (int j = 0; j < columnCount; j++)
                    cell[i, j] = table.Rows[i][j].ToString();

            ws.get_Range((Range)(ws.Cells[6, 1]), (Range)(ws.Cells[rowCount + 5, columnCount])).Value2 = cell;

            Range r = ws.get_Range((Range)(ws.Cells[rowCount + 7, 1]),(Range)(ws.Cells[rowCount + 7,columnCount]));
            r.MergeCells = true;
            r.Value2 = "Ho Chi Minh, " + DateTime.Now.ToLongDateString();
            r.HorizontalAlignment = XlHAlign.xlHAlignRight;


            Range sign = ws.get_Range((Range)(ws.Cells[rowCount + 9, 1]), (Range)(ws.Cells[rowCount + 9, columnCount]));
            sign.MergeCells = true;
            sign.Font.Bold = true;
            sign.HorizontalAlignment = XlHAlign.xlHAlignRight;

            ws.Rows.AutoFit();
            ws.Columns.AutoFit();

            wb.SaveAs(fileName);
            wb.Close(true, misValue, misValue);


            xlApp.Quit();
            releaseObject(ws);
            releaseObject(wb);
            releaseObject(xlApp);

            System.Diagnostics.Process.Start(fileName);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
