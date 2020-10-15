using CsvPad.Csv;

namespace CsvPad
{
    /// <summary>
    /// Service locator abstraction.
    /// </summary>
    public abstract class ServiceLocator
    {
        /// <summary>
        /// Singleton.
        /// </summary>
        public static ServiceLocator Instance
        {
            get; protected set;
        }

        /// <summary>
        /// Gets an instance of CsvService.
        /// </summary>
        /// <returns></returns>
        public abstract CsvService GetCsvService();
    }
}
