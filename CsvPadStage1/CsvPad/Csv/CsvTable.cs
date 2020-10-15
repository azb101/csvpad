using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CsvPad.Csv
{
    /// <summary>
    /// A data container of a CSV table.
    /// </summary>
    public class CsvTable
    {
        /// <summary>
        /// Gets or sets the header (column names) of the CSV table.
        /// </summary>
        public CsvRecord Header { get; set; }

        /// <summary>
        /// Gets or sets the location of the CSV table.
        /// </summary>
        public Uri Location { get; set; }

        /// <summary>
        /// Gets or sets the settings of the CSV table.
        /// </summary>
        public CsvSettings Settings { get; set; }

        /// <summary>
        /// Gets or sets the records of the CSV table.
        /// </summary>
        public List<CsvRecord> Records { get; set; } = new List<CsvRecord>();

        /// <summary>
        /// Gets a CSV record of a given index.
        /// </summary>
        /// <param name="index">The index of the CSV record.</param>
        /// <returns></returns>
        public CsvRecord this[int index] { get { return Records[index]; } }
    }
}
