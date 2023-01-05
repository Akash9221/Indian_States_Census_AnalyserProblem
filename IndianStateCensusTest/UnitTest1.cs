using IndianStatesCensusAnalyserProblem;
namespace IndianStateCensusTest
{
    public class Tests
    {
        public static string stateCensusCSVFilePath = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCensusData.csv";
        public static string stateCensusWrongCSVFilePath = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCensus.csv";
        public static string stateCensusIncorrectCSVFileType = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCensus.txt";
        public static string stateCensusWrongDelimeterCSVFileType = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\WrongDelimeterStateCensusData.csv";
        public static string stateCensusIncorrectHeaderCSVFileType = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\IncorrectHeaderStateCensusData.csv";
        [Test]
        public void GivenStateCensusData_WhenAnalyze_ShouldReturnNumberOfRecordMatches()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            CSVStateCensus cSVStateCensus = new CSVStateCensus();
            Assert.AreEqual(cSVStateCensus.ReadStateCensusData(stateCensusCSVFilePath), stateCensusAnalyzer.ReadStateCensusData(stateCensusCSVFilePath));

        }
        [Test]
        public void GivenStateCensusDataFileIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            try
            {
                int record = stateCensusAnalyzer.ReadStateCensusData(stateCensusWrongCSVFilePath);
            }
            catch(StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect FilePath");
            }
        }
        [Test]
        public void GivenStateCensusDataFileTypeIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            try
            {
                int record = stateCensusAnalyzer.ReadStateCensusData(stateCensusIncorrectCSVFileType);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect FileType");
            }
        }
        [Test]
        public void GivenStateCensusDataDelimeterIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer(); 
            try
            {
                int record = stateCensusAnalyzer.ReadStateCensusData(stateCensusWrongDelimeterCSVFileType);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter Incorrect");
            }
        }
        [Test]
        public void GivenStateCensusDataFileIncorrectHeader_WhenAnalyzed_ShouldReturnException()
        {
            StateCensusAnalyzer stateCensusAnalyzer = new StateCensusAnalyzer();
            try
            {
                bool records = stateCensusAnalyzer.ReadStateCensusData(stateCensusIncorrectHeaderCSVFileType, "State,Population,AreaInSqKm,DensityPerSqKm");
                Assert.IsTrue(records);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Header is Incorrect");
            }
        }
    }
}