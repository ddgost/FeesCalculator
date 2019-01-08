using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;

namespace FeesCalculator
{

    public partial class App : Application
    {
        public App()

        {

        }
        // Setting App culture to polish to avoid errors in DatePicker stemming from Month/Day/Year order.
        protected override void OnStartup(StartupEventArgs e)

        {

            Thread.CurrentThread.CurrentCulture = new CultureInfo("pl-PL");

            Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");

            FrameworkElement.LanguageProperty.OverrideMetadata(

                typeof(FrameworkElement),

                new FrameworkPropertyMetadata(

                    XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));

            base.OnStartup(e);

        }
    }
}
