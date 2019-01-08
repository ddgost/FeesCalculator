using System.Windows;
using FeesCalculator.ViewModel;

namespace FeesCalculator
{
    public partial class UtilityWindow : Window
    {
        public UtilityWindow()
        {
            InitializeComponent();
            DataContext = new UtilitiesViewModel();
        }
    }
}
