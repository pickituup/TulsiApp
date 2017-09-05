using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public sealed class WelcomePageViewModel : ViewModelBase, IViewModel {

        public ICommand StartCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public WelcomePageViewModel() {
            StartCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.DashboardPage));
        }

        public void Dispose() {
            
        }
    }
}
