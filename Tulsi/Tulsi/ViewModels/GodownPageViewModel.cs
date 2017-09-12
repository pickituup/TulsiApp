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
        public ObservableCollection<GodownData> GodownSource {
            get { return _godownSource; }
            set { SetProperty(ref _godownSource, value); }
        }

        //  Navigate to SearchPage.
        public ICommand DisplaySearchPageCommand { get; private set; }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public GodownPageViewModel() {
            GodownSource = GetData();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        private ObservableCollection<GodownData> GetData() {
            return new ObservableCollection<GodownData>() {
                new GodownData() {
                    Date = DateTime.Now,
                    Data = new List<GodownEntry> {
                        new GodownEntry { Cases = "430", Owner = "KFC Lokender" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "29", Owner = "NS Cuttack" },
                        new GodownEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new GodownData() {
                    Date = DateTime.Now,
                    Data = new List<GodownEntry> {
                        new GodownEntry { Cases = "430", Owner = "KFC Lokender" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "29", Owner = "NS Cuttack" },
                        new GodownEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new GodownData() {
                    Date = DateTime.Now,
                    Data = new List<GodownEntry> {
                        new GodownEntry { Cases = "29", Owner = "NS Cuttack" },
                        new GodownEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new GodownData() {
                    Date = DateTime.Now,
                    Data = new List<GodownEntry> {
                        new GodownEntry { Cases = "430", Owner = "KFC Lokender" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "29", Owner = "NS Cuttack" },
                        new GodownEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new GodownData() {
                    Date = DateTime.Now,
                    Data = new List<GodownEntry> {
                        new GodownEntry { Cases = "430", Owner = "KFC Lokender" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "29", Owner = "NS Cuttack" },
                        new GodownEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                },
                new GodownData() {
                    Date = DateTime.Now,
                    Data = new List<GodownEntry> {
                        new GodownEntry { Cases = "430", Owner = "KFC Lokender" },
                        new GodownEntry { Cases = "289", Owner = "RKO Ramrsh" },
                        new GodownEntry { Cases = "29", Owner = "NS Cuttack" },
                        new GodownEntry { Cases = "29", Owner = "SSA Delhi" }
                    }
                }
            };
        }

        public void Dispose() {
            GodownSource.Clear();
        }
    }
}
