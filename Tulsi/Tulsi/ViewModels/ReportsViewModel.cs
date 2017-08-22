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
    public class ReportsViewModel : ViewModelBase, IViewModel {

        private readonly ReportsMenuContainer _menuContainer;

        List<ReportsMenuItem> _menuItems;
        public List<ReportsMenuItem> MenuItems {
            get { return _menuItems; }
            set { SetProperty(ref _menuItems, value); }
        }

        ReportsMenuItem _selectedMenuItem;
        public ReportsMenuItem SelectedMenuItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {
                    BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(value.ViewType);

                    SelectedMenuItem = null;
                }
            }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        public ReportsViewModel() {
            _menuContainer = new ReportsMenuContainer();

            MenuItems = _menuContainer.BuildReportsMenuItems();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
        }

        public void Dispose() {
            
        }
    }
}
