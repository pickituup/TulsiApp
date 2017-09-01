using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Xamarin.Forms;
using System.Windows.Input;

namespace Tulsi.ViewModels {
    public sealed class ExpensesListViewModel : ViewModelBase, IViewModel {
        /// <summary>
        ///     ctor().
        /// </summary>
        public ExpensesListViewModel() {
            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        
        public void Dispose() {
            
        }
    }
}
