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
    public class LadaanPageViewModel : ViewModelBase, IViewModel {

        ObservableCollection<LaddanData> _ladaanSource = new ObservableCollection<LaddanData>();
        private object _selectedLadaanTransaction;

        /// <summary>
        ///     ctor().
        /// </summary>
        public LadaanPageViewModel() {
            HARDCDED_DATA_INSERT();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
            LooseTransactionSelectionCommand = new Command(() => {
                SelectedLadaanTransaction = null;
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<LaddanData> LadaanSource {
            get { return _ladaanSource; }
            set { SetProperty(ref _ladaanSource, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public object SelectedLadaanTransaction {
            get => _selectedLadaanTransaction;
            set => SetProperty<object>(ref _selectedLadaanTransaction, value);
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
            LadaanSource.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        private void HARDCDED_DATA_INSERT() {
            LadaanSource = new ObservableCollection<LaddanData>() {
                new LaddanData{
                    Date =DateTime.Now,
                    Data = new List<LadaanEntryTransaction>{
                        new LadaanEntryTransaction { Name = "NS Cuttack", Boxes = "29",
                            Ammounted =30000, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =3000, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Laddan/Bijak", IsPendingRates = false },
                        new LadaanEntryTransaction { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =300000, City="San Jose", Date=DateTime.Now,
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =300000000, City="Vancouver", Date=DateTime.Now,
                            InvoiceNumber ="00187", Status="Rated",
                            Type ="Laddan/Bijak", IsPendingRates = false }
                }},
                new LaddanData{
                    Date =DateTime.Now,
                    Data = new List<LadaanEntryTransaction>{
                        new LadaanEntryTransaction { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Laddan/Bijak", IsPendingRates = false },
                        new LadaanEntryTransaction { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Laddan/Bijak", IsPendingRates = false },
                        new LadaanEntryTransaction { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Boston", Date=DateTime.Now,
                            InvoiceNumber ="0235", Status="Rated",
                            Type ="Laddan/Bijak", IsPendingRates = false },
                        new LadaanEntryTransaction { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "AR Cuttack", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true }
                }},
                new LaddanData{
                    Date =DateTime.Now,
                    Data = new List<LadaanEntryTransaction>{
                        new LadaanEntryTransaction { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "SFT Bharampur", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "AR Cuttack", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true }
                }},
                new LaddanData{
                    Date =DateTime.Now,
                    Data = new List<LadaanEntryTransaction>{
                        new LadaanEntryTransaction { Name = "NS Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "SFT Bharampur", Boxes = "28",
                            InvoiceNumber ="00317", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true },
                        new LadaanEntryTransaction { Name = "AR Cuttack", Boxes = "28",
                            Ammounted =100, City="Houston", Date=DateTime.Now,
                            InvoiceNumber ="00387", Status="Pending rates",
                            Type ="Laddan/Bijak", IsPendingRates = true }
                }}
            };
        }
    }
}
