using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.MVVM.Core;
using Xamarin.Forms;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;

namespace Tulsi.ViewModels {
    public sealed class BankAccountsViewModel : ViewModelBase {
        /// <summary>
        /// Public ctor.
        /// </summary>
        public BankAccountsViewModel() {
            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }
    }
}
