using TheLedgerCoCalculator.Models;
using TheLedgerCoCalculator.Services;

namespace TheLedgerCoCalculatorTests.Services
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorServiceTests()
        {
            _calculatorService = new CalculatorService();
        }

        [TestMethod]
        [DataRow(5, 1000, 55)]
        [DataRow(40, 8000, 20)]
        public void GetTotalAmountPaidToDate_LoanIsProvided_BalanceIsAlsoProvided_PaymentIsNull(int numberOfEquatedMonthlyInstallments,
            int totalAmountPaidToDate, int monthlyInstallmentsRemaining)
        {
            var borrower = new Borrower("IDIDI", "Dale");
            var loanInfo = new Loan(borrower, 10000, 5, 4);
            var balanceQuery = new Balance(borrower, numberOfEquatedMonthlyInstallments);

            var sut = _calculatorService.GetLoanRepaymentInfo(balanceQuery, loanInfo);

            Assert.IsNotNull(sut);
            Assert.AreEqual((decimal)totalAmountPaidToDate, sut.TotalAmountPaidToDate);
            Assert.AreEqual((decimal)monthlyInstallmentsRemaining, sut.MonthlyInstallmentsRemaining);
        }

        [TestMethod]
        [DataRow(0, 0, 24)]
        public void GetTotalAmountPaidToDateForHarry_LoanIsProvided_BalanceIsAlsoProvided_PaymentIsNull(int numberOfEquatedMonthlyInstallments,
            int totalAmountPaidToDate, int monthlyInstallmentsRemaining)
        {
            var borrower = new Borrower("MBI", "Harry");
            var loanInfo = new Loan(borrower, 2000, 2, 2);
            var balanceQuery = new Balance(borrower, numberOfEquatedMonthlyInstallments);

            var sut = _calculatorService.GetLoanRepaymentInfo(balanceQuery, loanInfo);

            Assert.IsNotNull(sut);
            Assert.AreEqual((decimal)totalAmountPaidToDate, sut.TotalAmountPaidToDate);
            Assert.AreEqual((decimal)monthlyInstallmentsRemaining, sut.MonthlyInstallmentsRemaining);
        }

        [TestMethod]
        [DataRow(6, 3652, 4)]
        [DataRow(9, 4978, 1)]
        public void GetTotalAmountPaidToDateForDale_LoanAndBalanceIsProvided_PaymentIsNotNull(int numberOfEquatedMonthlyInstallments,
            int totalAmountPaidToDate, int monthlyInstallmentsRemaining)
        {
            var borrower = new Borrower("IDIDI", "Dale");
            var loanInfo = new Loan(borrower, 5000, 1, 6);
            var lumpSumPayment = new Payment(borrower, 1000, 5);
            var balanceQuery = new Balance(borrower, numberOfEquatedMonthlyInstallments);

            var sut = _calculatorService.GetLoanRepaymentInfo(balanceQuery, loanInfo, lumpSumPayment);

            Assert.IsNotNull(sut);
            Assert.AreEqual((decimal)totalAmountPaidToDate, sut.TotalAmountPaidToDate);
            Assert.AreEqual((decimal)monthlyInstallmentsRemaining, sut.MonthlyInstallmentsRemaining);
        }

        [TestMethod]
        [DataRow(15856, 3)]
        public void GetTotalAmountPaidToDate_LoanAndBalanceIsProvided_PaymentIsNotNull(int totalAmountPaidToDate, int monthlyInstallmentsRemaining)
        {
            var borrower = new Borrower("UON", "Shelly");
            var loanInfo = new Loan(borrower, 15000, 2, 9);
            var lumpSumPayment = new Payment(borrower, 7000, 12);
            var balanceQuery = new Balance(borrower, 12);

            var sut = _calculatorService.GetLoanRepaymentInfo(balanceQuery, loanInfo, lumpSumPayment);

            Assert.IsNotNull(sut);
            Assert.AreEqual((decimal)totalAmountPaidToDate, sut.TotalAmountPaidToDate);
            Assert.AreEqual((decimal)monthlyInstallmentsRemaining, sut.MonthlyInstallmentsRemaining);
        }
    }
}