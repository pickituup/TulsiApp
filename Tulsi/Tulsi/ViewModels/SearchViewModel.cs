using System.Collections.ObjectModel;
using Tulsi.MVVM.Core;

namespace Tulsi.ViewModels {
    public class SearchViewModel : ViewModelBase, IViewModel {

        bool _isBuyers;
        public bool IsBuyers {
            get { return _isBuyers; }
            set { SetProperty(ref _isBuyers, value); }
        }

        ObservableCollection<string> _result;
        public ObservableCollection<string> Result {
            get { return _result; }
            set { SetProperty(ref _result, value); }
        }

        string _selectedMenuItem;
        public string SelectedMenuItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && string.IsNullOrEmpty(value)) {
                    // Do something
                }
            }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public SearchViewModel() {
            Result = new ObservableCollection<string>();
            Result.Add("SKC Arjun");
            Result.Add("MCK Irfan");
            Result.Add("VB Bitto");
            Result.Add("MFC Vickey");
        }

        public void Dispose() {

        }
    }
}
