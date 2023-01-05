using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class StateCensusAnalyzer
    {
        public int ReadStateCensusData(string filepath)
        {
            //Tc1.2
            if (!File.Exists(filepath))
            {
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.FILE_INCORRECT, "Incorrect FilePath");
            }
            //Tc1.3
            if (!filepath.EndsWith(".csv"))
            {
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.TYPE_INCORRECT, "Incorrect FileType");
            }
            //TC1.4
            var read = File.ReadAllLines(filepath);
            string header = read[0];
            if (header.Contains("-"))
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.DELIMETER_INCORRECT, "Delimeter Incorrect");
            //Tc1.1
            using (var reader = new StreamReader(filepath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StateCensusData>().ToList();
                foreach (var data in records)
                {
                    //Console.WriteLine($"State name: {data.State} Population: {data.Population} AreaInSqKm :{data.AreaInSqKm} DensityPerSqKm: {data.DensityPerSqKm}");
                    Console.WriteLine(data);
                }
                return records.Count - 1;
            }
        }
        //TC1.5
        public bool ReadStateCensusData(string filepath, string header)
        {
            var read = File.ReadAllLines(filepath);
            string headers = read[0];
            if (headers.Equals(header))
                return true;
            else
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.HEADER_INCORRECT, "Header is Incorrect");

        }
    }
}
