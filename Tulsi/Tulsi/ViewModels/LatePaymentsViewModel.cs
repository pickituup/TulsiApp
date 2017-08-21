using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class LatePaymentsViewModel : ViewModelBase, IViewModel {
        private LatePayment _selectedLatePayment;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public LatePaymentsViewModel() {
            LatePayments = new List<LatePayment>()
            {
                new LatePayment { Name = "SKC Arjun", Amount=78000 },
                new LatePayment { Name = "DFC Mickey", Amount=78000 },
                new LatePayment { Name = "KK Nandu", Amount=78000 },
                new LatePayment { Name = "(M) Henu", Amount=78000 },
                new LatePayment { Name = "SF", Amount=78000 },
                new LatePayment { Name = "PJB", Amount=78000 }
            };

            DisplaySearchPageCommand = new Command(()=> {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public List<LatePayment> LatePayments { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public LatePayment SelectedLatePayment {
            get => _selectedLatePayment;
            set {
                if (SetProperty<LatePayment>(ref _selectedLatePayment, value) && 
                    value != null) {

                    BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BuyerProfilePage);

                    SelectedLatePayment = null;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            
        }
    }
}
