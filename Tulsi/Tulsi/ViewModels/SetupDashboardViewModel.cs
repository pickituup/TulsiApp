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
    public sealed class SetupDashboardViewModel : ViewModelBase, IViewModel {

        // Navigate to Search page.
        public ICommand DisplaySearchPageCommand { get; private set; }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public SetupDashboardViewModel() {
            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        public void Dispose() {
            
        }

        public void ReSubscribe() {
            
        }
    }
}
