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
    public sealed class ChatViewModel : ViewModelBase, IViewModel {

        public ICommand ClosePageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ChatViewModel() {

            // TODO: if close command executed => maybe need to clear chat or something.
            ClosePageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        public void Dispose() {
        }

        public void ReSubscribe() {
            
        }
    }
}
