using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDK.APaF.AqualogImport
{
    public class AqualogImport
    {
        /*
            Reading xls file:
            https://github.com/ExcelDataReader/ExcelDataReader

            FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);

            //1. Reading from a binary Excel file ('97-2003 format; *.xls)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

            //2. Reading from a OpenXml Excel file (2007 format; *.xlsx)
            IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

            //3. DataSet - The result of each spreadsheet will be created in the result.Tables
            DataSet result = excelReader.AsDataSet();

            //4. DataSet - Create column names from first row
            excelReader.IsFirstRowAsColumnNames = true;
            DataSet result = excelReader.AsDataSet();

            //5. Data Reader methods
            while (excelReader.Read())
            {
                //excelReader.GetInt32(0);
            }

            //6. Free resources (IExcelDataReader is IDisposable)
            excelReader.Close();


        */
        #region Constructor
        public AqualogImport()
        { }
        #endregion

        #region Public Methods
        public void ImportFish(string xlsFile)
        {

        }

        public void ImportPlants(string xlsFile)
        {

        }
        #endregion
    }
}
