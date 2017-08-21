using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Xamarin.Forms;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;

namespace Tulsi.ViewModels {
    public sealed class BuyerProfileViewModel : ViewModelBase,IViewModel {
        private ProfileTransaction _selectedProfileTransaction;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public BuyerProfileViewModel() {
            TransactionsData = new List<ProfileTransaction>()
            {
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=false, Quantity="8,200" },
                new ProfileTransaction{ Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
                new ProfileTransaction { Code = "SKC", Number = "28", IsP=true, Quantity="8,200" },
            };

            CloseCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            });
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand CloseCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<ProfileTransaction> TransactionsData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ProfileTransaction SelectedProfileTransaction {
            get { return _selectedProfileTransaction; }
            set {
                SetProperty<ProfileTransaction>(ref _selectedProfileTransaction, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            
        }
    }
}
