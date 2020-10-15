using System.IO;

namespace CsvPad.Csv
{
    /// <summary>
    /// An interface containing an operations for serialization and deserialization of a CSV table.
    /// </summary>
    public interface CsvSerializer
    {
        /// <summary>
        /// Serializes a CSV table.
        /// </summary>
        /// <param name="writer">The output.</param>
        /// <param name="table">The CSV table to serialize.</param>
        void Serialize(TextWriter writer, CsvTable table);

        /// <summary>
        /// Deserializes a CSV table.
        /// </summary>
        /// <param name="reader">The input.</param>
        /// <param name="settings">The settings of the CSV table.</param>
        /// <returns></returns>
        CsvTable Deserialize(TextReader reader, CsvSettings settings);
    }
}
