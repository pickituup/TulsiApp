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
    public class AuditLogViewModel : ViewModelBase, IViewModel {

        ObservableCollection<AuditEntry> _auditData;
        public ObservableCollection<AuditEntry> AuditData {
            get { return _auditData; }
            set { SetProperty(ref _auditData, value); }
        }

        AuditEntry _selectedMenuItem;
        public AuditEntry SelectedMenuItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {
                    // Do something
                }
            }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public AuditLogViewModel() {
            AuditData = new ObservableCollection<AuditEntry>()
            {
                new AuditEntry { Action = "Modified Buyer", Code = "SKC" },
                new AuditEntry { Action = "Changed Rates", Code = "SKC" },
                new AuditEntry { Action = "Deposit Received", Code = "MKC" },
                new AuditEntry { Action = "Modified Buyer", Code = "SKC" },
                new AuditEntry { Action = "Changed Rates", Code = "SKC" },
                new AuditEntry { Action = "Deposit Received", Code = "MKC" },
            };

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
        }

        public void Dispose() {
            
        }
    }
}
