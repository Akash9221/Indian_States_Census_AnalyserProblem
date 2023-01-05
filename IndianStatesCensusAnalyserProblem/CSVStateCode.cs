using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace IndianStatesCensusAnalyserProblem
{
    public class CSVStateCode
    {
        public int ReadStateCodeData(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<StateCodeData>().ToList();
                foreach (var data in records)
                {
                    Console.WriteLine(data);
                    //Console.WriteLine($"SrialNo: {data.SrNo}\tState Name: {data.StateName}\tTIN: {data.TIN}\tStateCode: {data.StateCode}");
                }
                return records.Count-1;
            }
        }
    }
}
