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

        /// <summary>
        ///     Navigate back.
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        /// <summary>
        ///     Log out from current profile.
        /// </summary>
        public ICommand LogOutCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ProfilePageViewModel() {
            CloseCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            });

            LogOutCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.LoginPage);
            });
        }

        public void Dispose() {
        }
    }
}
