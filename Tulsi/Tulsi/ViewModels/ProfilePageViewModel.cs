using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;

namespace Tulsi.ViewModels {
    public sealed class ProfilePageViewModel : ViewModelBase, IViewModel {
        
        public ProfilePageViewModel() {
            ClosePageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            });

            LogOutCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.LoginPage);
            });
        }

        /// <summary>
        /// Close current page through Tulsi.NavigationFramework.NavigateOneStepBack().
        /// </summary>
        public ICommand ClosePageCommand { get; private set; }

        /// <summary>
        /// Logs out from current profile
        /// </summary>
        public ICommand LogOutCommand { get; private set; }

       
        public void Dispose() { }

        public void ReSubscribe() {
            
        }
    }
}
