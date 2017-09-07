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

namespace Tulsi.ViewModels.Content {
    public sealed class ExpensesListViewModel : ViewModelBase, IViewModel {
       
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ExpensesListViewModel() {
            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });
        }

        public void Dispose() {

        }
    }
}
