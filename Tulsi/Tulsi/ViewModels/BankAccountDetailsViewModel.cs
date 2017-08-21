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
    public sealed class BankAccountDetailsViewModel : ViewModelBase {
        /// <summary>
        /// Public ctor.
        /// </summary>
        public BankAccountDetailsViewModel() {
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