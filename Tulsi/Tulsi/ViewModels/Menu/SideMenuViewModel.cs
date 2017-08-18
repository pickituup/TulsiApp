using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Menu;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels.Menu {
    public sealed class SideMenuViewModel : ViewModelBase, IViewModel {

        private readonly SideMenuContainer _sideMenuContainer;

        /// <summary>
        ///     Side menu items
        /// </summary>
        List<Tulsi.Menu.SideMenuItem> _sideMenuItems;
        public List<Tulsi.Menu.SideMenuItem> SideMenuItems {
            get { return _sideMenuItems; }
            set { SetProperty(ref _sideMenuItems, value); }
        }

        /// <summary>
        ///     Selected menu item.
        /// </summary>
        Tulsi.Menu.SideMenuItem _selectedSideMenuItem;
        public Tulsi.Menu.SideMenuItem SelectedSideMenuItem {
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

            DisplayProfitPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ProfitPage);
            });
        }

        public void Dispose() {

        }
    }
}