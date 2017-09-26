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

namespace Tulsi.ViewModels {
    public sealed class BankAccountDetailsViewModel : ViewModelBase, IViewModel {

        ObservableCollection<BankAccountData> _bankAccountDataSource;
        public object _selectedBankAccountTransaction;

        /// <summary>
        ///     ctor().
        /// </summary>
        public BankAccountDetailsViewModel() {
            HARDCODED_DATA_INSERT();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            LooseTransactionSelectionCommand = new Command(() => {
                SelectedBankAccountTransaction = null;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<BankAccountData> BankAccountSource {
            get { return _bankAccountDataSource; }
            set { SetProperty(ref _bankAccountDataSource, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public object SelectedBankAccountTransaction {
            get => _selectedBankAccountTransaction;
            set => SetProperty<object>(ref _selectedBankAccountTransaction, value);
        }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        //  Navigate to Search Page.
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICommand LooseTransactionSelectionCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {

        }

        /// <summary>
        /// 
        /// </summary>
        private void HARDCODED_DATA_INSERT() {
            BankAccountSource = new ObservableCollection<BankAccountData>() {
                new BankAccountData() {
                    Date = DateTime.Now,
                    Title = "Owner",
                    Description = "Amount",
                    Data = new List<BankAccountEntry>() {
                        new BankAccountEntry() {
                            Name = "KFC Locender",
                            Boxes = "340",
                            Date = DateTime.Now,
                            Ammounted = 30000,
                            IsPendingRates = false,
                            Type = "Debit",
                            Status = "Paid to",
                            Description = "SBI/Deduct/00923#"
                        },
                        new BankAccountEntry() {
                            Name = "KFO Kavalek",
                            Boxes = "140",
                            Date = DateTime.Now,
                            Ammounted = 33000,
                            IsPendingRates = true,
                            Type = "Debit",
                            Status = "Pending",
                            Description = "SBI/Deduct/00924#"
                        },
                        new BankAccountEntry() {
                            Name = "HFC Shtuergjik",
                            Boxes = "740",
                            Date = DateTime.Now,
                            Ammounted = 300000,
                            IsPendingRates = false,
                            Type = "Debit",
                            Status = "Paid to",
                            Description = "SBI/Deduct/00923#"
                        },
                    }
                },
                new BankAccountData() {
                    Date = DateTime.Now,
                    Title = "Owner",
                    Description = "Amount",
                    Data = new List<BankAccountEntry>() {
                        new BankAccountEntry() {
                            Name = "KFO Kavalek",
                            Boxes = "140",
                            Date = DateTime.Now,
                            Ammounted = 33000,
                            IsPendingRates = true,
                            Type = "Debit",
                            Status = "Pending",
                            Description = "SBI/Deduct/00924#"
                        },
                        new BankAccountEntry() {
                            Name = "KFC Locender",
                            Boxes = "340",
                            Date = DateTime.Now,
                            Ammounted = 30000,
                            IsPendingRates = false,
                            Type = "Debit",
                            Status = "Paid to",
                            Description = "SBI/Deduct/00923#"
                        },
                        new BankAccountEntry() {
                            Name = "HFC Shtuergjik",
                            Boxes = "740",
                            Date = DateTime.Now,
                            Ammounted = 300000,
                            IsPendingRates = false,
                            Type = "Debit",
                            Status = "Paid to",
                            Description = "SBI/Deduct/00923#"
                        },
                        new BankAccountEntry() {
                            Name = "KFC Locender",
                            Boxes = "340",
                            Date = DateTime.Now,
                            Ammounted = 30000,
                            IsPendingRates = false,
                            Type = "Debit",
                            Status = "Paid to",
                            Description = "SBI/Deduct/00923#"
                        }
                    }
                },
                new BankAccountData() {
                    Date = DateTime.Now,
                    Title = "Owner",
                    Description = "Amount",
                    Data = new List<BankAccountEntry>() {
                        new BankAccountEntry() {
                            Name = "KFC Locender",
                            Boxes = "340",
                            Date = DateTime.Now,
                            Ammounted = 30000,
                            IsPendingRates = false,
                            Type = "Debit",
                            Status = "Paid to",
                            Description = "SBI/Deduct/00923#"
                        },
                        new BankAccountEntry() {
                            Name = "KFO Kavalek",
                            Boxes = "140",
                            Date = DateTime.Now,
                            Ammounted = 33000,
                            IsPendingRates = true,
                            Type = "Debit",
                            Status = "Pending",
                            Description = "SBI/Deduct/00924#"
                        },
                        new BankAccountEntry() {
                            Name = "KFO Kavalek",
                            Boxes = "140",
                            Date = DateTime.Now,
                            Ammounted = 33000,
                            IsPendingRates = true,
                            Type = "Debit",
                            Status = "Pending",
                            Description = "SBI/Deduct/00924#"
                        },
                    }
                },
            };
        }
    }
}