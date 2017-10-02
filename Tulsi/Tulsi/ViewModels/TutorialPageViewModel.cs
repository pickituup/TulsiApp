using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model.DataContainers;
using Tulsi.Model.DataContainers.DataItems;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public sealed class TutorialPageViewModel : ViewModelBase, IViewModel {

        private readonly TutorialsContainer _tutorialsContainer;

        List<TutorialItem> _tutorials;
        public List<TutorialItem> Tutorials {
            get { return _tutorials; }
            set { SetProperty(ref _tutorials, value); }
        }

        public ICommand LoginCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public TutorialPageViewModel() {
            _tutorialsContainer = new TutorialsContainer();

            LoginCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.LoginPage);
            });

            Tutorials = _tutorialsContainer.BuildProfitMenuItems();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            Tutorials?.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ChangeStatusBarColor(string hexColor) {
            DependencyService.Get<IDeviceServices>().ChangeStatusBarColor(hexColor);
        }
    }
}
