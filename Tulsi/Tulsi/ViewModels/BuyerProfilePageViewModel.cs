using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Xamarin.Forms;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using System.Collections.ObjectModel;

namespace Tulsi.ViewModels {
    public sealed class BuyerProfilePageViewModel : ViewModelBase, IViewModel {

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
        public BuyerProfilePageViewModel() {
            BaseSingleton<NavigationObserver>.Instance.SendToBuyerProfileTransAction += OnSendToBuyerProfileTransAction;

            CloseCommand = new Command(() => {
                TransactionsData.Clear();
                BaseSingleton<NavigationObserver>.Instance.OnCloseView();
            });
        }

        private void OnSendToBuyerProfileTransAction(object sender, NavigationFramework.NavigationArgs.ProfileTransactionEventArgs e) {
            foreach (var item in e.Data) {
                TransactionsData.Add(item);
            }
        }

        public void Dispose() {
            BaseSingleton<NavigationObserver>.Instance.SendToBuyerProfileTransAction -= OnSendToBuyerProfileTransAction;
            //BaseSingleton<NavigationObserver>.Instance.SendToBuyerProfileTransAction -= OnSendProfileTransAction;
        }

        public void ReSubscribe() {
            
        }
    }
}
