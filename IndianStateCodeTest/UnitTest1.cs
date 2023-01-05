using IndianStatesCensusAnalyserProblem;
namespace IndianStateCodeTest
{
    public class Tests
    {
        public static string stateCodeCSVFilePath = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\StateCode.csv";
        public static string stateCodeWrongCSVFilePath = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\State.csv";
        public static string stateCodeIncorrectCSVFileType = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\State.txt";
        public static string stateCodeWrongDelimeterCSVFileType = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\WrongDelimeterStateCodeData.csv";
        public static string stateCodeIncorrectheaderCSVFileType = @"E:\Practice\IndianStatesCensusAnalyserProblem\IndianStatesCensusAnalyserProblem\File\IncorrectHeaderStateCodeData.csv";

        [Test]
        public void GivenStateCodeData_WhenAnalyze_ShouldReturnNumberOfRecordMatches()
        {
            StateCodeAnalyzer stateCodeAnalyzer = new StateCodeAnalyzer();
            CSVStateCode cSVStateCode = new CSVStateCode();
            Assert.AreEqual(cSVStateCode.ReadStateCodeData(stateCodeCSVFilePath), stateCodeAnalyzer.ReadStateCodeData(stateCodeCSVFilePath));

        }
        [Test]
        public void GivenStateCodeDataFileIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCodeAnalyzer stateCodeAnalyzer = new StateCodeAnalyzer();
            try
            {
                int record = stateCodeAnalyzer.ReadStateCodeData(stateCodeWrongCSVFilePath);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect FilePath");
            }
        }
        [Test]
        public void GivenStateCodeDataFileTypeIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCodeAnalyzer stateCodeAnalyzer = new StateCodeAnalyzer();
            try
            {
                int record = stateCodeAnalyzer.ReadStateCodeData(stateCodeIncorrectCSVFileType);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Incorrect FileType");
            }
        }
        [Test]
        public void GivenStateCodeDataDelimeterIncorrect_WhenAnalyzed_ShouldReturnException()
        {
            StateCodeAnalyzer stateCodeAnalyzer = new StateCodeAnalyzer();
            try
            {
                int record = stateCodeAnalyzer.ReadStateCodeData(stateCodeWrongDelimeterCSVFileType);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Delimeter Incorrect");
            }
        }
        [Test]
        public void GivenStateCodeDataFileIncorrectHeader_WhenAnalyzed_ShouldReturnException()
        {
            StateCodeAnalyzer stateCodeAnalyzer = new StateCodeAnalyzer();
            try
            {
                bool records = stateCodeAnalyzer.ReadStateCodeData(stateCodeIncorrectheaderCSVFileType, "SrNo,StateName,TIN,StateCode");
                Assert.IsTrue(records);
            }
            catch (StateCensusAndCodeException ex)
            {
                Assert.AreEqual(ex.Message, "Header is Incorrect");
            }
        }
    }
}