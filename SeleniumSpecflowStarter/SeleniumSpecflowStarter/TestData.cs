using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NPOI.XSSF.UserModel;
using NUnit.Framework;
using SeleniumSpecflowStarter.Models;

namespace SeleniumSpecflowStarter
{
    public class TestData

    {
        public static Broker ReadExcel(int rownum)
        {
            var broker = new Broker();
            string path = @"D:\Waqas\Projects\Automation\Specflow\data.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(0);
            var row = sheet.GetRow(rownum);
            broker.BrokerName = row.GetCell(0).StringCellValue.Trim();
            broker.BrokerNumber = row.GetCell(1).NumericCellValue.ToString().Trim();
            broker.IssueDate = row.GetCell(2).DateCellValue;
            broker.OfficeNumber = row.GetCell(3).NumericCellValue.ToString().Trim();
            broker.OfficeIssueDate = row.GetCell(4).DateCellValue;
            broker.OfficeActivity = row.GetCell(5).StringCellValue.Trim();
            broker.TransactionYear= row.GetCell(6).NumericCellValue.ToString().Trim();
            broker.TransactionResidential = row.GetCell(7).NumericCellValue.ToString().Trim();
            broker.TransactionCommercial = row.GetCell(8).NumericCellValue.ToString().Trim();
            broker.TransactionTotal = row.GetCell(9).NumericCellValue.ToString().Trim();
            broker.ProjectName = row.GetCell(10).StringCellValue.Trim();
            broker.ProjTransactions = row.GetCell(11).NumericCellValue.ToString().Trim();
            broker.ProjectsTotal= row.GetCell(12).NumericCellValue.ToString().Trim();
            broker.RankYear = row.GetCell(13).NumericCellValue.ToString().Trim();
            broker.RankPoints = row.GetCell(14).NumericCellValue.ToString().Trim();
            broker.Awards = row.GetCell(15).StringCellValue.Trim();
            broker.BrokerMobile = row.GetCell(16).StringCellValue.Trim();
            broker.BrokerArea = row.GetCell(17).StringCellValue.Trim();
            return broker;

        }
        public static Office ReadExcelOffice(int rownum)
        {
            var office = new Office();
            string path = @"D:\Waqas\Projects\Automation\Specflow\data.xlsx";
            XSSFWorkbook workbook = new XSSFWorkbook(File.Open(path, FileMode.Open));
            var sheet = workbook.GetSheetAt(1);
            var row = sheet.GetRow(rownum);
            office.OfficeName = row.GetCell(0).StringCellValue.Trim();
            office.officeNumber = row.GetCell(1).NumericCellValue.ToString().Trim();
            office.licenseIssue = row.GetCell(2).StringCellValue.ToString().Trim();
            office.licenseExpiry = row.GetCell(3).StringCellValue.ToString().Trim();
            office.officeActivity = row.GetCell(4).StringCellValue.Trim();
            office.officeBrokerCount = row.GetCell(5).StringCellValue.Trim();
            office.officeRank = row.GetCell(6).NumericCellValue.ToString().Trim();
            office.officeAward = row.GetCell(7).StringCellValue.Trim();





            return office;
        }
   }
}
