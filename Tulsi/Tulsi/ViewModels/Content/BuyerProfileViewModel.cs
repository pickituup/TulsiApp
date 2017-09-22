using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.NavigationFramework.NavigationArgs;
using Xamarin.Forms;

namespace Tulsi.ViewModels.Content {
    public sealed class BuyerProfileViewModel : ViewModelBase, IViewModel {

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
        public BuyerProfileViewModel() {
            BaseSingleton<NavigationObserver>.Instance.SendToBuyerProfileTransAction += OnSendToBuyerProfileTransAction;

            CloseCommand = new Command(OnCloseCommand);
        }

        private void OnSendToBuyerProfileTransAction(object sender, ProfileTransactionEventArgs e) {
            foreach (var item in e.Data) {
                TransactionsData.Add(item);
            }
        }

        /// <summary>
        ///     Close view, which binding with this viewModel.
        /// </summary>
        /// <param name="obj"></param>
        private void OnCloseCommand(object obj) {
            SelectedMenuItem = null;
            TransactionsData.Clear();

            BaseSingleton<NavigationObserver>.Instance.OnCloseView();
        }

        public void Dispose() {
            BaseSingleton<NavigationObserver>.Instance.SendToBuyerProfileTransAction -= OnSendToBuyerProfileTransAction;
            TransactionsData = null;
        }
    }
}
