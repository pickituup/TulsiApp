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
        public ObservableCollection<ColdStoreData> ColdStoreSource {
            get { return _coldStoreSource; }
            set { SetProperty(ref _coldStoreSource, value); }
        }

        //  Navigate to SearchPage.
        public ICommand DisplaySearchPageCommand { get; private set; }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ColdStorePageViewModel() {
            ColdStoreSource = GetData();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        private ObservableCollection<ColdStoreData> GetData() {
            return new ObservableCollection<ColdStoreData>() {
                new ColdStoreData() {
                    Date = DateTime.Now,
                    Data = new List<ColdStoreEntry> {
                        new ColdStoreEntry { Cases = "430", Owner = "KFC Lokender" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "29", Owner = "NS Cuttack" },
                        new ColdStoreEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new ColdStoreData() {
                    Date = DateTime.Now,
                    Data = new List<ColdStoreEntry> {
                        new ColdStoreEntry { Cases = "430", Owner = "KFC Lokender" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "29", Owner = "NS Cuttack" },
                        new ColdStoreEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new ColdStoreData() {
                    Date = DateTime.Now,
                    Data = new List<ColdStoreEntry> {
                        new ColdStoreEntry { Cases = "29", Owner = "NS Cuttack" },
                        new ColdStoreEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new ColdStoreData() {
                    Date = DateTime.Now,
                    Data = new List<ColdStoreEntry> {
                        new ColdStoreEntry { Cases = "430", Owner = "KFC Lokender" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "29", Owner = "NS Cuttack" },
                        new ColdStoreEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new ColdStoreData() {
                    Date = DateTime.Now,
                    Data = new List<ColdStoreEntry> {
                        new ColdStoreEntry { Cases = "430", Owner = "KFC Lokender" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "29", Owner = "NS Cuttack" },
                        new ColdStoreEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new ColdStoreData() {
                    Date = DateTime.Now,
                    Data = new List<ColdStoreEntry> {
                        new ColdStoreEntry { Cases = "430", Owner = "KFC Lokender" },
                        new ColdStoreEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new ColdStoreEntry { Cases = "29", Owner = "NS Cuttack" },
                        new ColdStoreEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                }
            };
        }

        public void Dispose() {
            ColdStoreSource.Clear();
        }
    }
}
