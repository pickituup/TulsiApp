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
    public sealed class BankAccountsViewModel : ViewModelBase, IViewModel {

        ObservableCollection<BankAccount> _bankAccounts;
        public ObservableCollection<BankAccount> BankAccounts {
            get { return _bankAccounts; }
            set { SetProperty(ref _bankAccounts, value); }
        }

        BankAccount _selectedBankAccount;
        public BankAccount SelectedBankAccount {
            get => _selectedBankAccount;
            set {
                if (SetProperty<BankAccount>(ref _selectedBankAccount, value) && value != null) {
                    //
                    // TODO: BankAccountDetailsPage must know which BankAccount we select, and dynamicaly
                    // work out that selected object. So current implementation is temporary.
                    //
                    BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BankAccountDetailsPage);

                    //
                    // Also deselect last selected BankAccount.
                    //
                    SelectedBankAccount = null;
                }
            }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public BankAccountsViewModel() {
            BankAccounts = GetBankAccounts();

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });
        }

        public ObservableCollection<BankAccount> GetBankAccounts() {
            return new ObservableCollection<BankAccount>() {
                new BankAccount() {
                    LogoPath = "Tulsi.Images.icici_logo.png",
                    Ammount = 3200000,
                    SomeDescription = "IN SOFTWARE",
                    LastUpdateInfo = "last update 42 hours ago"
                },
                new BankAccount() {
                    LogoPath = "Tulsi.Images.pnb_logo.png",
                    Ammount = 4000000,
                    SomeDescription = "IN SOFTWARE",
                    LastUpdateInfo = "last update 42 hours ago"
                }
            };
        }

        public void Dispose() {
            BankAccounts.Clear();
        }
    }
}
