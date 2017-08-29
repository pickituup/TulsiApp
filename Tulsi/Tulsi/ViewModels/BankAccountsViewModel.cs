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
using Tulsi.Model;

namespace Tulsi.ViewModels {
    public sealed class BankAccountsViewModel : ViewModelBase, IViewModel {

        public List<BankAccount> BankAccounts { get; private set; }

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
            BankAccounts = new List<BankAccount>() {
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

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });
        }

        public void Dispose() {

        }
    }
}
