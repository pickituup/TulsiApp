using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
