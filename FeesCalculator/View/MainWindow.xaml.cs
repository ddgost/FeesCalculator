using FeesCalculator.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using FeesCalculator.Model;

namespace FeesCalculator
{
    public partial class MainWindow : Window
    {
        private AppContext Context { get; } = new AppContext();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            Show();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Notification == "ShowUtilityWindow")
            {
                var UtilityWindow = new UtilityWindow();
                UtilityWindow.Show();
            }
        }
    }
}