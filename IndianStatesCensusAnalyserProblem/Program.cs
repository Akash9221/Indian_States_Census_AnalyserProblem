namespace IndianStatesCensusAnalyserProblem
{
    internal class Program
    {
        public static string stateCensusCSVFilePath = @"E:\Practice\Indian_Census_Program\Indian_States_Census_AnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCensusData.csv";

        public static string stateCodeCSVFilePath = @"E:\Practice\Indian_Census_Program\Indian_States_Census_AnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCode.csv";
        static void Main(string[] args)
        {
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            cSVStateCensus.ReadStateCensusData(stateCensusCSVFilePath); //Reading StateCensus CSV File

            CSVStateCode cSVStateCode = new CSVStateCode();
            cSVStateCode.ReadStateCodeData(stateCodeCSVFilePath); //Reading StateCode CSV File
        }
    }
}