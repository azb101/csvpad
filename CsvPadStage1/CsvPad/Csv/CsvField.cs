namespace CsvPad.Csv
{
    /// <summary>
    /// A data container of a field in a CSV table.
    /// </summary>
    public class CsvField
    {
        /// <summary>
        /// Gets or sets an identifier of the field.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a value of the field.
        /// </summary>
        public string Value { get; set; }
    }
}
