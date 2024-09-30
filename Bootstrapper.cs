using Caliburn.Micro;
using System.Windows;
using WPFWithCaliburnMicro.ViewModels;

namespace WPFWithCaliburnMicro
{
    public class Bootstrapper : BootstrapperBase
    {
        public Bootstrapper()
        {
            Initialize();
        }

        protected async override void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewForAsync<ShellViewModel>();
        }
    }
}
