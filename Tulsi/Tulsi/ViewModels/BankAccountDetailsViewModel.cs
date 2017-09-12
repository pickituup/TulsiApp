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
        public ObservableCollection<BankAccountData> BankAccountSource {
            get { return _bankAccountDataSource; }
            set { SetProperty(ref _bankAccountDataSource, value); }
        }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        //  Navigate to Search Page.
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public BankAccountDetailsViewModel() {
            BankAccountSource = GetData();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());


        }

        private ObservableCollection<BankAccountData> GetData() {
            return new ObservableCollection<BankAccountData>() {
                new BankAccountData() {
                    Title = "Description",
                    Description = "Amount",
                    Date = DateTime.Now,
                    Data = new List<BankAccountEntry> {
                        new BankAccountEntry { Cases = "430", Owner = "KFC Lokender", ColorFrame = Color.Red },
                        new BankAccountEntry { Cases = "289", Owner = "RKO Ramrsh", ColorFrame = Color.Green },
                        new BankAccountEntry { Cases = "29", Owner = "NS Cuttack", ColorFrame = Color.Red },
                        new BankAccountEntry { Cases = "29", Owner = "SSA Delhi", ColorFrame = Color.Green }
                    }
                },
                new BankAccountData() {
                    Title = "Owner",
                    Description = "Cases",
                    Date = DateTime.Now,
                    Data = new List<BankAccountEntry> {
                        new BankAccountEntry { Cases = "430", Owner = "KFC Lokender", ColorFrame = Color.Green },
                        new BankAccountEntry { Cases = "289", Owner = "RKO Ramrsh", ColorFrame = Color.Red },
                        new BankAccountEntry { Cases = "289", Owner = "RKO Ramrsh", ColorFrame = Color.Green },
                        new BankAccountEntry { Cases = "289", Owner = "RKO Ramrsh", ColorFrame = Color.Green },
                        new BankAccountEntry { Cases = "29", Owner = "NS Cuttack", ColorFrame = Color.Green },
                        new BankAccountEntry { Cases = "29", Owner = "SSA Delhi", ColorFrame = Color.Red }
                    }
                }
            };
        }
        public void Dispose() {

        }
    }
}