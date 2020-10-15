namespace CsvPad.Csv
{
    /// <summary>
    /// A data container of a CSV table settings.
    /// </summary>
    public class CsvSettings
    {
        /// <summary>
        /// Gets or sets a logical value that specifies whether a CSV table has the header 
        /// (the first line of the CSV table that contains the names of the columns).
        /// Default: true.
        /// </summary>
        public virtual bool Header { get; set; } = true;

        /// <summary>
        /// Gets or sets a separator for the fields in a CSV table.
        /// </summary>
        public virtual string Separator { get; set; } = ";";
    }
}
