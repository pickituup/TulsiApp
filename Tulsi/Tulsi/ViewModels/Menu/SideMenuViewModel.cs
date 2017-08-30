using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.Model.DataContainers;
using Tulsi.Model.DataContainers.DataItems;

namespace Tulsi.ViewModels.Menu {
    public sealed class SideMenuViewModel : ViewModelBase, IViewModel {

        private readonly SideMenuContainer _sideMenuContainer;

        /// <summary>
        ///     Side menu items
        /// </summary>
        List<SideMenuItem> _sideMenuItems;
        public List<SideMenuItem> SideMenuItems {
            get { return _sideMenuItems; }
            set { SetProperty(ref _sideMenuItems, value); }
        }

        /// <summary>
        ///     Selected menu item.
        /// </summary>
        SideMenuItem _selectedSideMenuItem;
        public SideMenuItem SelectedSideMenuItem {
            get { return _selectedSideMenuItem; }
            set {
                if (SetProperty(ref _selectedSideMenuItem, value) && value != null) {
                    BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(value.ViewType);
                }
            }
        }

        public ICommand DisplayProfitPageCommand { get; set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public SideMenuViewModel() {
            _sideMenuContainer = new SideMenuContainer();

            SideMenuItems = _sideMenuContainer.BuildSideMenuItems(); 

            DisplayProfitPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ProfitPage));
        }

        public void Dispose() {

        }

        public void ReSubscribe() {
            
        }
    }
}