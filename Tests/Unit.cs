using Hypo;
using Hypo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Unit
    {
        [Fact]
        public void GetRentModelTest()
        {

            var viewModel = new MainViewModel();


            var rentModel = viewModel.GetRentModel(2, 28000, 36000, 1);

            Assert.Equivalent(new RentModel { MonthlyPayment = 5333, MonthlyRent = 106 }, new RentModel { MonthlyPayment = (int)rentModel.MonthlyPayment, MonthlyRent = (int)rentModel.MonthlyRent });
        }

        [Fact]
        public void GetRentAmountTest()
        {
            var viewModel = new MainViewModel();

            var result = viewModel.GetRentAmount(20);

            Assert.Equal(4.5, result);
        }
    }
}
