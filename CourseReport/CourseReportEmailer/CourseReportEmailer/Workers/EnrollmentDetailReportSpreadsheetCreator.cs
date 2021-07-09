using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Newtonsoft.Json;
using CourseReportEmailer.Models;

namespace CourseReportEmailer.Workers
{
    class EnrollmentDetailReportSpreadsheetCreator
    {
        public void Create(string fileName, List<EnrollmentDetailReportModel> enrollmentModels)
        {
            using(SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                // object to json, then json to data table
                var json = JsonConvert.SerializeObject(enrollmentModels);
                DataTable table = (DataTable)JsonConvert.DeserializeObject(json, typeof(DataTable));

                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                SheetData sheetData = new SheetData();
                worksheetPart.Worksheet = new Worksheet(sheetData);

                Sheets sheetList = document.WorkbookPart.Workbook.AppendChild<Sheets>(new Sheets());
                Sheet singleSheet = new Sheet()
                {
                    Id = document.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Report Sheet"
                };

                sheetList.Append(singleSheet);
                // put in the header row
                Row excelTitleRow = new Row();
                foreach(DataColumn tableColumn in table.Columns)
                {
                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(tableColumn.ColumnName);
                    excelTitleRow.Append(cell);
                }
                sheetData.AppendChild(excelTitleRow);

                // and the data
                foreach(DataRow tableRow in table.Rows)
                {
                    Row excelNewRow = new Row();
                    foreach(DataColumn tableColumn in table.Columns)
                    {
                        Cell cell = new Cell();
                        cell.DataType = CellValues.String;
                        cell.CellValue = new CellValue(tableRow[tableColumn.ColumnName].ToString());
                        excelNewRow.AppendChild(cell);
                    }
                    sheetData.AppendChild(excelNewRow);
                }

                workbookPart.Workbook.Save();
            }
        }
    }
}
