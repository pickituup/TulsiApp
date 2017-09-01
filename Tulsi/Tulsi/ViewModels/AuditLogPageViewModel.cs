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
    public class AuditLogPageViewModel : ViewModelBase, IViewModel {

        private ObservableCollection<AuditEntry> _auditData;
        public ObservableCollection<AuditEntry> AuditData {
            get { return _auditData; }
            set { SetProperty(ref _auditData, value); }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        public ICommand SelectItemCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public AuditLogPageViewModel() {
            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            SelectItemCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.AuditLogDetailsPage));

            HARDCODED_DATA_INSERT();
        }

        private void HARDCODED_DATA_INSERT() {
            AuditData = new ObservableCollection<AuditEntry>() {
                new AuditEntry() {
                    Date = DateTime.Now,
                    AuditActions = new List<AuditAction>() {
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC" },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" },
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC"  }
                    }
                },
                new AuditEntry() {
                    Date = DateTime.Now,
                    AuditActions = new List<AuditAction>() {
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC" },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" },
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC"  },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" }
                    }
                },
                new AuditEntry() {
                    Date = DateTime.Now,
                    AuditActions = new List<AuditAction>() {
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC" },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" }
                    }
                },
                new AuditEntry() {
                    Date = DateTime.Now,
                    AuditActions = new List<AuditAction>() {
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC" },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" },
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC"  },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" }
                    }
                },
                new AuditEntry() {
                    Date = DateTime.Now,
                    AuditActions = new List<AuditAction>() {
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC"  },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" }
                    }
                },
                new AuditEntry() {
                    Date = DateTime.Now,
                    AuditActions = new List<AuditAction>() {
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC" },
                    }
                },
                new AuditEntry() {
                    Date = DateTime.Now,
                    AuditActions = new List<AuditAction>() {
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC" },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" },
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC"  },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" },
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC"  },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" }
                    }
                },
                new AuditEntry() {
                    Date = DateTime.Now,
                    AuditActions = new List<AuditAction>() {
                        new AuditAction() { Action = "Modified Buyer", Code = "SKC" },
                        new AuditAction() { Action = "Changed Rates", Code = "SKC"  },
                        new AuditAction() { Action = "Deposit Received", Code = "MKC" }
                    }
                }
            };
        }

        public void Dispose() {
            AuditData.Clear();
        }
    }
}
