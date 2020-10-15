using System;
using CsvPad.Csv;

namespace CsvPad
{
    /// <summary>
    /// C# implementation of the ServiceLocator.
    /// </summary>
    public class CustomServiceLocator : ServiceLocator
    {
        private static string _csvRootDirectory;

        private static object Locker = new object();

        public static void Initialize(string csvRootDirectory)
        {
            _csvRootDirectory = csvRootDirectory;


            if (Instance == null)
            {
                lock (Locker)
                {
                    if (Instance == null)
                    {
                        Instance = new CustomServiceLocator();
                    }
                }
            }
        }



        public override CsvService GetCsvService()
        {
            return new FileCsvService(new CustomSerializer(), _csvRootDirectory);
        }
    }
}
