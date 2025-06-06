using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace CustomerImportSQL.Utils;

public static class CsvFileImport
{
    /// <summary>
    /// Opens a CSV file at a given filepath and reads its contents into a 
    /// data table.
    /// </summary>
    /// <param name="csvFilePath">The selected file from an open file dialog</param>
    /// <returns>DataTable with columns and rows read from CSV file</returns>
    public static async Task<DataTable> GetDataViewFromCsvFileAsync(string csvFilePath)
    {
        DataTable dt = new DataTable();
        TextFieldParser parser = new TextFieldParser(csvFilePath);
        
        parser.SetDelimiters(",");

        if (!parser.EndOfData)
        {
            // create columns
            string[]? cols = await Task.Run(() => parser.ReadFields());

            foreach (var col in cols!)
            {
                dt.Columns.Add(col);
            }
        }

        while (!parser.EndOfData)
        {
            string[]? row = await Task.Run(() => parser.ReadFields());

            dt.Rows.Add(row);
        }
        return dt;
    }
}