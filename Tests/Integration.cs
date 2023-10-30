
using Hypo.ViewModels;

namespace Tests
{
    public class Integration
    {
        [Fact]
        public void CalculateMaxDebt()
        {
            var viewModel = new MainViewModel();

            viewModel.HasDebt = false;
            viewModel.Period = 1;
            viewModel.PartnerIncome = "28000";
            viewModel.MonthlyIncome = "36000";
            viewModel.Postcode = "6533";

            var result = viewModel.CalculateResult();

            Assert.Equivalent(new MaxDebtResult { MaxDebt = 272000 }, new MaxDebtResult { MaxDebt = result.MaxDebt});       
        }

        [Fact]
        public void CalculateMaxDebtWithStudentLoan()
        {
            var viewModel = new MainViewModel();

            viewModel.HasDebt = true;
            viewModel.Period = 1;
            viewModel.PartnerIncome = "28000";
            viewModel.MonthlyIncome = "36000";
            viewModel.Postcode = "6533";

            var result = viewModel.CalculateResult();

            Assert.Equivalent(new MaxDebtResult { MaxDebt = 204000 }, new MaxDebtResult { MaxDebt = result.MaxDebt });
        }

        [Fact]
        public void DisallowedPostcodeGivesError()
        {
            var viewModel = new MainViewModel();

            viewModel.HasDebt = false;
            viewModel.Period = 1;
            viewModel.PartnerIncome = "28000";
            viewModel.MonthlyIncome = "36000";
            viewModel.Postcode = "9679";

            var result = viewModel.CalculateResult();

            Assert.NotNull(result.ErrorMessage);
        }
    }

    public class MaxDebtResult
    {
        public double MaxDebt { get; set; }
    }
}