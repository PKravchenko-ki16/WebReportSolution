using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace WebReportSolution.ClientMVC.Infrastructure.Report
{
    public class GeneratingReport
    {
        public MemoryStream Generating(DataTable table)
        {
            MemoryStream memoryStream = new MemoryStream();
            using (var fs = new FileStream("Result.xlsx", FileMode.Create, FileAccess.Write))
            {
                XSSFWorkbook workbook = new XSSFWorkbook();
                ISheet excelSheet = workbook.CreateSheet("Sheet1");

                List<String> columns = new List<string>();
                IRow row = excelSheet.CreateRow(0);
                int columnIndex = 0;

                // if columns are needed in Russian, create manually

                //columns.Add("Дата"); 
                //row.CreateCell(0).SetCellValue("Дата");
                //columns.Add("Количество заказов с суммой от 0 до 1000");
                //row.CreateCell(1).SetCellValue("Количество заказов с суммой от 0 до 1000");
                //columns.Add("Количество заказов с суммой от 1001 до 5000");
                //row.CreateCell(2).SetCellValue("Количество заказов с суммой от 1001 до 5000");
                //columns.Add("Количество заказов с суммой от 5001");
                //row.CreateCell(3).SetCellValue("Количество заказов с суммой от 5001");

                foreach (System.Data.DataColumn column in table.Columns)
                {
                    columns.Add(column.ColumnName);
                    row.CreateCell(columnIndex).SetCellValue(column.ColumnName);
                    columnIndex++;
                }

                int rowIndex = 1;
                foreach (DataRow dsrow in table.Rows)
                {
                    row = excelSheet.CreateRow(rowIndex);
                    int cellIndex = 0;
                    foreach (String col in columns)
                    {
                        row.CreateCell(cellIndex).SetCellValue(dsrow[col].ToString());
                        cellIndex++;
                    }

                    rowIndex++;
                }
                workbook.Write(memoryStream);
            }

            return memoryStream;
        }
    }
}