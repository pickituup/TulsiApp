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
    public sealed class GodownPageViewModel : ViewModelBase, IViewModel {

        ObservableCollection<GodownData> _godownSource;
        private object _selectedGoDownTransaction;

        /// <summary>
        ///     ctor().
        /// </summary>
        public GodownPageViewModel() {
            HARDCDED_DATA_INSERT();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
            LooseTransactionSelectionCommand = new Command(() => {
                SelectedGoDownTransaction = null;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public object SelectedGoDownTransaction {
            get => _selectedGoDownTransaction;
            set => SetProperty<object>(ref _selectedGoDownTransaction, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<GodownData> GodownSource {
            get { return _godownSource; }
            set { SetProperty(ref _godownSource, value); }
        }

        /// <summary>
        /// Navigate to SearchPage.
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// Navigate back.
        /// </summary>
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICommand LooseTransactionSelectionCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            GodownSource.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        private void HARDCDED_DATA_INSERT() {
            GodownSource = new ObservableCollection<GodownData>() {
                new GodownData {
                    Date = DateTime.Now,
                    Data = new List<GodownEntry>{
                        new GodownEntry { Name = "NS Cuttack", Boxes = "29",
                            Ammounted =30000, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =3000, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Godown", IsPendingRates = false },
                        new GodownEntry { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =300000, City="San Jose", Date=DateTime.Now,
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =300000000, City="Vancouver", Date=DateTime.Now,
                            InvoiceNumber ="00187", Status="Rated",
                            Type ="Godown", IsPendingRates = false }
                }},
                new GodownData{
                    Date =DateTime.Now,
                    Data = new List<GodownEntry>{
                        new GodownEntry { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Godown", IsPendingRates = false },
                        new GodownEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Godown", IsPendingRates = false },
                        new GodownEntry { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Godown", IsPendingRates = false },
                        new GodownEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "AR Cuttack", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true }
                }},
                new GodownData{
                    Date =DateTime.Now,
                    Data = new List<GodownEntry>{
                        new GodownEntry { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "AR Cuttack", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true }
                }},
                new GodownData{
                    Date =DateTime.Now,
                    Data = new List<GodownEntry>{
                        new GodownEntry { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new GodownEntry { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true }
                }}
            };
        }
    }
}
