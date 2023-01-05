namespace IndianStatesCensusAnalyserProblem
{
    internal class Program
    {

        public static string stateCensusCSVFilePath = @"D:\Brizlab\All.netprog\NewBatch\IndianStateCensusProblems\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCensusData.csv";

        public static string stateCodeCSVFilePath = @"D:\Brizlab\All.netprog\NewBatch\IndianStateCensusProblems\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCode.csv";
        static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Enter the option : \n1.For State Census \n2.For State Code");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        CSVStateCensus cSVStateCensus = new CSVStateCensus();
                        cSVStateCensus.ReadStateCensusData(stateCensusCSVFilePath); //Reading StateCensus CSV File
                        break;
                    case 2:
                        CSVStateCode cSVStateCode = new CSVStateCode();
                        cSVStateCode.ReadStateCodeData(stateCodeCSVFilePath); //Reading StateCode CSV File
                        break;
                    default:
                        flag = false;
                        break;


                }
            }
        }
    }
}