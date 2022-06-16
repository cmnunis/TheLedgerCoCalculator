using TheLedgerCoCalculator.Services;

namespace TheLedgerCoCalculatorTests.Services
{
    [TestClass]
    public class FileReaderServiceTests
    {
        private readonly FileReaderService _fileReaderService;

        public FileReaderServiceTests()
        {
            _fileReaderService = new FileReaderService();
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void FilePathIsNullOrWhitespaceThrowsException(string value)
        {
            var sut = Assert.ThrowsException<ArgumentNullException>(() => _fileReaderService.GetAvailableInputFiles(value));
            Assert.AreEqual("path", sut.ParamName);
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow(" ")]
        public void FileNameIsNullOrWhitespaceThrowsException(string value)
        {
            var sut = Assert.ThrowsExceptionAsync<ArgumentNullException>(async () => await _fileReaderService.GetFileContentsAsync(value));
            Assert.AreEqual("fileName", sut.Result.ParamName);
        }
    }
}
