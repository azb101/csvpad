using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CsvPad.Csv
{
    /// <summary>
    /// C# implementation of the CsvSerializer.
    /// </summary>
    public class CustomSerializer : CsvSerializer
    {
        public CsvTable Deserialize(TextReader reader, CsvSettings settings)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");

            if (settings == null)
                throw new ArgumentNullException("settings");

            CsvTable table = new CsvTable();
            table.Settings = settings;

            string allText = reader.ReadToEnd();
            string[] rows = allText.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            System.Diagnostics.Debugger.Launch();
            if (settings.Header)
            {
                table.Header = ParseCsvRecord(rows[0], settings);
                rows = rows.Skip(1).ToArray();
            }

            foreach(string row in rows)
            {
                table.Records.Add(ParseCsvRecord(row, settings));
            }

            return table;
        }

        private CsvRecord ParseCsvRecord(string row, CsvSettings settings)
        {
            if (string.IsNullOrEmpty(row))
                throw new ArgumentNullException("row");

            if (settings == null)
                throw new ArgumentNullException("settings");


            var record = new CsvRecord();

            foreach (var col in row.Split(settings.Separator.ToCharArray(), StringSplitOptions.None))
            {
                record.Fields.Add(new CsvField() { Value = col });
            }

            return record;
        }

        public void Serialize(TextWriter writer, CsvTable table)
        {
            if (writer == null)
                throw new ArgumentNullException("writer");

            if (table == null)
                throw new ArgumentNullException("table");

            if (table.Settings == null)
                throw new Exception("CsvTable.Setting cannot be null");

            StringBuilder sb = new StringBuilder();
            if (table.Settings.Header && table.Header != null)
            {
                foreach (var field in table.Header.Fields)
                {
                    sb.AppendFormat("{0}{1}", field.Value, table.Settings.Separator);
                }

                sb.Append(Environment.NewLine);
            }

            if (table.Records != null)
            {
                foreach (var record in table.Records)
                {
                    foreach (var field in record.Fields)
                    {
                        sb.AppendFormat("{0}{1}", field.Value, table.Settings.Separator);
                    }

                    sb.Append(Environment.NewLine);
                }
            }

            writer.Write(sb.ToString());
        }
    }
}
