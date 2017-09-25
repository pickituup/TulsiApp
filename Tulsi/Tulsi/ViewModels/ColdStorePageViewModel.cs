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
    public sealed class ColdStorePageViewModel : ViewModelBase, IViewModel {

        ObservableCollection<ColdStoreData> _coldStoreSource;
        public object _selectedColdStoreTransaction;

        /// <summary>
        ///     ctor().
        /// </summary>
        public ColdStorePageViewModel() {
            HARDCDED_DATA_INSERT();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
            LooseTransactionSelectionCommand = new Command(() => {
                SelectedColdStoreTransaction = null;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<ColdStoreData> ColdStoreSource {
            get { return _coldStoreSource; }
            set { SetProperty(ref _coldStoreSource, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public object SelectedColdStoreTransaction {
            get => _selectedColdStoreTransaction;
            set => SetProperty<object>(ref _selectedColdStoreTransaction, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// 
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
            ColdStoreSource.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        private void HARDCDED_DATA_INSERT() {
            ColdStoreSource = new ObservableCollection<ColdStoreData>() {
                new ColdStoreData {
                    Date = DateTime.Now,
                    Data = new List<ColdStoreEntry>{
                        new ColdStoreEntry { Name = "NS Cuttack", Boxes = "29",
                            Ammounted =30000, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =3000, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Godown", IsPendingRates = false },
                        new ColdStoreEntry { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =300000, City="San Jose", Date=DateTime.Now,
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =300000000, City="Vancouver", Date=DateTime.Now,
                            InvoiceNumber ="00187", Status="Rated",
                            Type ="Godown", IsPendingRates = false }
                }},
                new ColdStoreData{
                    Date =DateTime.Now,
                    Data = new List<ColdStoreEntry>{
                        new ColdStoreEntry { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Godown", IsPendingRates = false },
                        new ColdStoreEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Godown", IsPendingRates = false },
                        new ColdStoreEntry { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Godown", IsPendingRates = false },
                        new ColdStoreEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "AR Cuttack", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true }
                }},
                new ColdStoreData{
                    Date =DateTime.Now,
                    Data = new List<ColdStoreEntry>{
                        new ColdStoreEntry { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "AR Cuttack", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true }
                }},
                new ColdStoreData{
                    Date =DateTime.Now,
                    Data = new List<ColdStoreEntry>{
                        new ColdStoreEntry { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true },
                        new ColdStoreEntry { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Godown", IsPendingRates = true }
                }}
            };
        }
    }
}
