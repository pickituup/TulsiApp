using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public sealed class ForgotPasscodePageViewModel : ViewModelBase, IViewModel {

        ImageSource _icon;
        public ImageSource Icon {
            get { return _icon; }
            set { SetProperty(ref _icon, value); }
        }

        // Cancel action.
        public ICommand CancelCommand { get; private set; }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        // Reset passcode and navigate to TutorialPage.
        public ICommand ResetCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ForgotPasscodePageViewModel() {
            Icon = ImageSource.FromStream(() => {
                Assembly assembly = GetType().GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.doctor2_800.gif");
                return stream;
            });

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            CancelCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            ResetCommand = new Command(() => {
                DependencyService.Get<ISQLiteService>().ClearPasscode();
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.LoginPage);
            });
        }

        public void Dispose() {

        }
    }
}
