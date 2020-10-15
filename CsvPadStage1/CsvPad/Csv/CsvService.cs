using System;
using System.Collections.Generic;

namespace CsvPad.Csv
{
    /// <summary>
    /// An interface providing CSV-related operations.
    /// </summary>
    public interface CsvService
    {
        /// <summary>
        /// Deletes a CSV table for a given location.
        /// </summary>
        /// <param name="location">The location of the existing CSV table.</param>
        void DeleteTable(Uri location);
        
        /// <summary>
        /// Gets a CSV table for a given location.
        /// </summary>
        /// <param name="location">The location of the existing CSV table.</param>
        /// <param name="settings">CSV settings.</param>
        CsvTable GetTable(Uri location, CsvSettings settings);

        /// <summary>
        /// Gets all locations of the CSV tables.
        /// </summary>
        /// <returns></returns>
        List<Uri> GetTableLocations();

        /// <summary>
        /// Saves a CSV table.
        /// </summary>
        /// <param name="table">The CSV table to save.</param>
        void SaveTable(CsvTable table);
        
        /// <summary>
        /// Validates a location of a CSV table.
        /// </summary>
        /// <param name="location">The location of the CSV table to validate.</param>
        /// <returns></returns>
        bool ValidateLocation(Uri location);
    }
}
