using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace FlyPig.Utility
{
    public class CsvHelper
    {
        public static DataTable ReadCsvToDataTable(string filePath)
        {
            if (!File.Exists(filePath)) return null;

            DataTable dataTable = new DataTable();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string lineContent = null;
                string[] contents = null;
                string[] tableHeads = null;
                int columnCount = -1;
                bool isFirstLine = true;

                while ((lineContent = sr.ReadLine()) != null)
                {
                    if (isFirstLine)
                    {
                        tableHeads = lineContent.Split(',');
                        columnCount = tableHeads.Length;
                        foreach (string head in tableHeads)
                        {
                            DataColumn column = new DataColumn(head);
                            dataTable.Columns.Add(column);
                        }

                        isFirstLine = false;
                    }
                    else
                    {
                        contents = lineContent.Split(',');
                        if (contents.Length > columnCount) return null;
                        DataRow row = dataTable.NewRow();
                        for (int i = 0; i < contents.Length; i++)
                        {
                            row[i] = contents[i];
                        }
                        dataTable.Rows.Add(row);
                    }
                }

                sr.Close();
            }

            return dataTable;
        }

        public static void WriteDataTableToCsv(DataTable table, string filePath)
        {
            StringBuilder sb = new StringBuilder();
            string[] columnNames = table.Columns.Cast<DataColumn>().
                                              Select(column => column.ColumnName).
                                              ToArray();
            sb.AppendLine(string.Join(",", columnNames));

            foreach (DataRow row in table.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                ToArray();
                sb.AppendLine(string.Join(",", fields));
            }
            File.WriteAllText(filePath, sb.ToString());
        }
    }
}
