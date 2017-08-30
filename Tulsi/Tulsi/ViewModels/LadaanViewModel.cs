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
    public class LadaanViewModel : ViewModelBase, IViewModel {

        ObservableCollection<LadaanEntry> _ladaanData;
        public ObservableCollection<LadaanEntry> LadaanData {
            get { return _ladaanData; }
            set { SetProperty(ref _ladaanData, value); }
        }

        LadaanEntry _selectedMenuItem;
        public LadaanEntry SelectedMenuItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {
                    // Do something
                }
            }
        }

        //  Navigate to SearchPage.
        public ICommand DisplaySearchPageCommand { get; private set; }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public LadaanViewModel() {
            LadaanData = new ObservableCollection<LadaanEntry>()
            {
                new LadaanEntry { Code = "NS Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "SFT Bharampur", Number = "285 Cases" },
                new LadaanEntry { Code = "AR Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "NS Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "SFT Bharampur", Number = "285 Cases" },
                new LadaanEntry { Code = "AR Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "SFT Bharampur", Number = "285 Cases" },
                new LadaanEntry { Code = "AR Cuttack", Number = "285 Cases" },
                new LadaanEntry { Code = "SFT Bharampur", Number = "285 Cases" },
            };

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        public void Dispose() {

        }

        public void ReSubscribe() {
            
        }
    }
}
