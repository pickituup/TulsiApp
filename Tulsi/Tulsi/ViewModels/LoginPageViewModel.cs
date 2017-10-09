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
    public sealed class LoginPageViewModel : ViewModelBase, IViewModel {

        public ICommand LoginCommand { get; private set; }

        public ICommand SignInCommand { get; private set; }

        public ICommand ForgotPasswordCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public LoginPageViewModel() {
            LoginCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.DashboardPage));

            SignInCommand = new Command(() => DisplayAlert("Navigation", "Sign up action", "OK"));

            ForgotPasswordCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.PasswordRecoveryPage));
        }

        public void Dispose() {
            
        }
    }
}
