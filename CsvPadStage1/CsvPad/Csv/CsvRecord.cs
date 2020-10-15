using System.Collections.Generic;

namespace CsvPad.Csv
{
    /// <summary>
    /// A data container of a line in a CSV table.
    /// </summary>
    public class CsvRecord
    {
        /// <summary>
        /// Gets or sets an identifier of the record.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a list of the fields of the record.
        /// </summary>
        public List<CsvField> Fields { get; set; } = new List<CsvField>();

        /// <summary>
        /// Gets a field of a given index.
        /// </summary>
        /// <param name="index">The index of the field.</param>
        public CsvField this[int index] { get { return Fields[index]; } }
    }
}
