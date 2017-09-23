using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using System.Windows.Input;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Tulsi.SharedService;
using Tulsi.NavigationFramework.NavigationArgs;

namespace Tulsi.ViewModels {
    public class LatePaymentsPageViewModel : ViewModelBase, IViewModel {

        private LatePayment _selectedLatePayment;
        public LatePayment SelectedItem {
            get => _selectedLatePayment;
            set {
                if (SetProperty<LatePayment>(ref _selectedLatePayment, value) && value != null) {
                    BaseSingleton<NavigationObserver>.Instance.OnLatePaymentsImportedSpot(ViewType.BuyerProfileView);
                    BaseSingleton<NavigationObserver>.Instance.OnSendToBuyerProfileTransAction(value.ProfileTransactions);

                    SelectedItem = null;
                }
            }
        }

        ObservableCollection<LatePayment> _latePayments;
        public ObservableCollection<LatePayment> LatePayments {
            get { return _latePayments; }
            set { SetProperty(ref _latePayments, value); }
        }

        IView _importedView;
        public IView ImportedView {
            get { return _importedView; }
            set {
                if (SetProperty(ref _importedView, value) && value != null)
                    Spot.TranslateTo(0, 0, 700);
            }
        }

        ContentView _spot;
        public ContentView Spot {
            get { return _spot; }
            set {
                if (SetProperty(ref _spot, value) && value != null)
                    HideView();
            }
        }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// Public ctor.
        /// </summary>
        public LatePaymentsPageViewModel() {
            BaseSingleton<NavigationObserver>.Instance.LatePaymentsImportedSpot += ImportingSpot;

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());


            LatePayments = GetLatePayments();
        }

        private void ImportingSpot(object sender, NavigationImportedEventArgs e) {
            ImportedView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType);
        }

        public async void CloseImportedView() {
            if (this.ImportedView != null) {
                await HideViewAsync();
                ImportedView.Dispose();
                ImportedView = null;
            }
        }

        public void NativeSenderCloseView() {
            CloseImportedView();
        }

        private async void HideView() => await HideViewAsync();

        private async Task HideViewAsync() {
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            await Spot.TranslateTo(0, displayHeight, 700);
        }

        private ObservableCollection<LatePayment> GetLatePayments() {
            return new ObservableCollection<LatePayment>()
            {
                new LatePayment { Name = "SKC Arjun", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    }},
                new LatePayment { Name = "DFC Mickey", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } },
                new LatePayment { Name = "KK Nandu", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } },
                new LatePayment { Name = "(M) Henu", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } },
                new LatePayment { Name = "SF", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } },
                new LatePayment { Name = "PJB", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } }
            };
        }


        public void Dispose() {
            BaseSingleton<NavigationObserver>.Instance.LatePaymentsImportedSpot -= ImportingSpot;
        }
    }
}
