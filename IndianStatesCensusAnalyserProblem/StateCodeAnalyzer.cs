using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public  class StateCodeAnalyzer
    {
        public int ReadStateCodeData(string filePath)
        {
            //Tc2.2
            if (!File.Exists(filePath))
            {
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.FILE_INCORRECT, "Incorrect FilePath");
            }
            //Tc2.3
            if (!filePath.EndsWith(".csv"))
            {
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.TYPE_INCORRECT, "Incorrect FileType");
            }
            //TC2.4
            var read = File.ReadAllLines(filePath);
            string header = read[0];
            if (header.Contains("-"))
                throw new StateCensusAndCodeException(StateCensusAndCodeException.ExceptionType.DELIMETER_INCORRECT, "Delimeter Incorrect");
            //Tc2.1
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StateCodeData>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data);
                    //Console.WriteLine($"SrialNo: {data.SrNo}\tState Name: {data.StateName}\tTIN: {data.TIN}\tStateCode: {data.StateCode}");
                }
                return records.Count - 1;
            }
        }
        //TC1.5
        public bool ReadStateCodeData(string filepath, string header)
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
