using Hypo.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Hypo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string[] BannedPostcodes = new string[] { "9679", "9681", "9682"};
        public event EventHandler<CalculationResult> ParseResultEvent;

        public string MonthlyIncome { get; set; } = "";
        public string PartnerIncome { get; set; } = "";
        public bool HasDebt { get; set; } = false;

        public string Postcode { get; set; } = "";
        public int Period { get; set; } = 1;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CalculationResult CalculateResult()
        {
            if (BannedPostcodes.Any(x => x == Postcode))
            {
                return new CalculationResult
                {
                    MaxDebt = 0,
                    ErrorMessage = "Postcode is not allowed"
                };
            }

            var result = new CalculationResult();

            var partnerIncome = double.Parse(PartnerIncome);
            var monthlyIncome = double.Parse(MonthlyIncome);

            result.MaxDebt = (partnerIncome + monthlyIncome) * 4.25;

            if (HasDebt)
            {
                result.MaxDebt = result.MaxDebt * 0.75;
            }

            double RentAmount = GetRentAmount(Period);
            var rentModel = GetRentModel(RentAmount, partnerIncome, monthlyIncome, Period);

            result.MonthlyRent = rentModel.MonthlyRent;
            result.MonthlyPayment = rentModel.MonthlyPayment;

            return result;
        }

        private ICommand _calculateCommand;
        public ICommand CalculateCommand
        {
            get
            {
                return _calculateCommand ?? (_calculateCommand = new CommandHandler(() => ParseResultEvent?.Invoke(this, CalculateResult()), () => true));
            }
        }
        

        /* Calculation Functies */
        public double GetRentAmount(int period)
        {
            return period switch
            {
                1 => 2,
                5 => 3,
                10 => 3.5,
                20 => 4.5,
                30 => 5,
                _ => 5
            };
        }
        public RentModel GetRentModel(double rentAmount, double partnerIncome, double monthlyIncome, int period)
        {
            var result = new RentModel();

            var Rent = (rentAmount / 100) / 12;
            result.MonthlyRent = (partnerIncome + monthlyIncome) * Rent;
            result.MonthlyPayment = (partnerIncome + monthlyIncome) / (period * 12);
            
            return result;
        }

    }

    public class RentModel
    {
        public double MonthlyRent { get; set; }
        public double MonthlyPayment { get; set;}
    }
}
