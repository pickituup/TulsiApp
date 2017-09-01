using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model.DataContainers;
using Tulsi.Model.DataContainers.DataItems;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public sealed class ArrivalPageViewModel : ViewModelBase, IViewModel {

        private readonly ArrivalsContainer _arrivalsContainer;

        List<ArrivalItem> _arrivalItems;
        public List<ArrivalItem> ArrivalItems {
            get { return _arrivalItems; }
            set { SetProperty(ref _arrivalItems, value); }
        }

        ArrivalItem _selectedMenuItem;
        public ArrivalItem SelectedItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {
                    BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ArrivalDetailPage);
                }
            }
        }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ArrivalPageViewModel() {
            _arrivalsContainer = new ArrivalsContainer();

            ArrivalItems = _arrivalsContainer.BuildArrivalstems();

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        public void Dispose() {
        }
    }
}
