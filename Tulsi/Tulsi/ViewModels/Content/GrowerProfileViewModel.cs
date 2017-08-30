using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels.Content {
    public sealed class GrowerProfileViewModel : ViewModelBase, IViewModel {

        ObservableCollection<ProfileTransaction> _transactionsData = new ObservableCollection<ProfileTransaction>();
        public ObservableCollection<ProfileTransaction> TransactionsData {
            get { return _transactionsData; }
            set { SetProperty(ref _transactionsData, value); }
        }

        ProfileTransaction _selectedMenuItem;
        public ProfileTransaction SelectedMenuItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {
                    // Do something
                }
            }
        }

        public ICommand CloseCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public GrowerProfileViewModel() {
            BaseSingleton<NavigationObserver>.Instance.SendProfileTransAction += OnSendProfileTransAction;

            CloseCommand = new Command(() => {
                TransactionsData.Clear();
                BaseSingleton<NavigationObserver>.Instance.OnCloseView();
            });
        }

        private void OnSendProfileTransAction(object sender, NavigationFramework.NavigationArgs.GrowerProfileTransactionEventArgs e) {
            foreach (var item in e.Data) {
                TransactionsData.Add(item);
            }
        }

        public void Dispose() {
            BaseSingleton<NavigationObserver>.Instance.SendProfileTransAction -= OnSendProfileTransAction;
        }

        public void ReSubscribe() {
            
        }
    }
}
