using System.Data;
using System.Diagnostics;
using Microsoft.VisualBasic.FileIO;

namespace CustomerImportSQL;

public static class CsvFileImport
{
    /// <summary>
    /// Opens a CSV file at a given filepath and reads its contents into a 
    /// data table.
    /// </summary>
    /// <param name="csvFilePath">the selected file from an open file dialog</param>
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
    
    // TODO: get this working. goal is to optimize file reading for fast data retrieval.
    public static async Task<DataTable> GetDataFromCsvFileAsync(string csvFilePath)
    {
        Stopwatch  stopwatch = new Stopwatch();
        stopwatch.Start();
        DataTable dt = new DataTable();
        using StreamReader sr = new StreamReader(csvFilePath);

        try
        {
            // get the column headers from the file
            string? colHeaders = await sr.ReadLineAsync();
            string[] headers = colHeaders!.Split(',');
            
            // create columns and add them to the table
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            
            // advance through each line in file to generate rows
            while (!sr.EndOfStream)
            {
                string? row = await sr.ReadLineAsync();
                string[] rowCells = row!.Split(',');
                dt.Rows.Add(rowCells);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            sr.Close();
        }
        stopwatch.Stop();
        Console.WriteLine(@"Original Method Time Elapsed: " + stopwatch.ElapsedMilliseconds);
        return dt;
    }
}