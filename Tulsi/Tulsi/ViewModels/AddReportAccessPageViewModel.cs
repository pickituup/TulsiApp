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
    public class AddReportAccessPageViewModel : ViewModelBase, IViewModel {

        /// <summary>
        /// 
        /// </summary>
        public AddReportAccessPageViewModel() {
            ClosePageCommand = new Command(() => {
                LeavePage();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ClosePageCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public void LeavePage() {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() { }
    }
}
