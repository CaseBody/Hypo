using Hypo.Classes;
using Hypo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hypo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainViewModel viewModel;
        public Result resultWindow;
        public MainWindow()
        {
            viewModel = new MainViewModel();
            viewModel.ParseResultEvent += ParseResult;

            this.DataContext = viewModel;
            InitializeComponent();
        }

        private void ParseResult(object sender, CalculationResult result)
        {
            resultWindow = new Result(result);
            resultWindow.Show();
            this.Close();
        }
    }
}
