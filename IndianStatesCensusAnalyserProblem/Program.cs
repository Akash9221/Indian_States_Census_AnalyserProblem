namespace IndianStatesCensusAnalyserProblem
{
    internal class Program
    {
        public static string stateCensusCSVFilePath = @"E:\Practice\Indian_Census_Program\Indian_States_Census_AnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCensusData.csv";

        
        static void Main(string[] args)
        {
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            cSVStateCensus.ReadStateCensusData(stateCensusCSVFilePath); //Reading StateCensus CSV File

           
        }
    }
}