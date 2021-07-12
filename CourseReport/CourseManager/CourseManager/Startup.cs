using System.Windows;
using Caliburn.Micro;
using CourseManager.ViewModels;

namespace CourseManager
{
    class Startup : BootstrapperBase
    {
        public Startup()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }
    }
}
