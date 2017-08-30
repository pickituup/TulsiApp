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
    public sealed class SettingsViewModel : ViewModelBase, IViewModel {

        public ICommand SetupDashboardPageCommand { get; private set; }

        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public SettingsViewModel() {
            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            SetupDashboardPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SetupDashboardPage));
        }

        public void Dispose() {
        }

        public void ReSubscribe() {
            
        }
    }
}
