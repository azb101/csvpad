using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static System.IO.File;

namespace CsvPad.Csv
{
    /// <summary>
    /// C# implementation of the CsvService. Works on a local files.
    /// </summary>
    public class FileCsvService : CsvService
    {
        private CsvSerializer _serializer;
        private string _root;

        public FileCsvService(CsvSerializer serializer, string rootDirectory)
        {
            _serializer = serializer;
            _root = rootDirectory;
        }


        public void DeleteTable(Uri location)
        {
            if (location == null || string.IsNullOrEmpty(location.AbsolutePath))
                throw new ArgumentNullException("location");

            if (!ValidateLocation(location))
                throw new Exception("seems location does not exists: " + location.ToString());

            try
            {
                File.Delete(location.LocalPath);
            }
            catch(Exception ex)
            {
                // log error here
                throw;
            }
        }


        public CsvTable GetTable(Uri location, CsvSettings settings)
        {
            if (location == null || string.IsNullOrEmpty(location.AbsolutePath))
                throw new ArgumentNullException("location");

            if (settings == null)
                throw new ArgumentNullException("setting");
            
            /*
            if (!ValidateLocation(location))
                throw new Exception("file seems does not exists");
            */

            using(var reader = File.OpenText(location.LocalPath))
            {
                var csvFile = _serializer.Deserialize(reader, settings);

                csvFile.Location = location;

                return csvFile;
            }
        }

        public List<Uri> GetTableLocations()
        {
            List<Uri> locations = new List<Uri>();

            try
            {
                if (string.IsNullOrWhiteSpace(_root))
                    throw new Exception("root cannot be empty");


                DirectoryInfo dir = new DirectoryInfo(_root);

                locations = dir.GetFiles("*.csv", SearchOption.AllDirectories)
                                .Select(s => new Uri(s.FullName)).OrderBy(s => s.AbsolutePath).ToList();
            }
            catch (Exception ex)
            {
                // log error;
            }

            return locations;
        }

        public void SaveTable(CsvTable table)
        {
            if (table == null)
                throw new ArgumentNullException("table");

            if (_serializer == null)
                throw new Exception("Serializer cannot be null");
            
            using (var tw = File.CreateText(table.Location.LocalPath))
            {
                _serializer.Serialize(tw, table);
            }
        }

        public bool ValidateLocation(Uri location)
        {
            if (location == null || string.IsNullOrEmpty(location.AbsolutePath))
                throw new ArgumentNullException("location");

            var reg = new Regex(@"file:///.{3,}(.csv)");

            return reg.IsMatch(location.AbsoluteUri);
        }
    }
}
