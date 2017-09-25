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
using Tulsi.Observers;

namespace Tulsi.ViewModels.Menu {
    public sealed class SideMenuViewModel : ViewModelBase, IViewModel {

        bool _amountVisible;
        public bool AmountVisible {
            get { return _amountVisible; }
            set { SetProperty(ref _amountVisible, value); }
        }

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
            AmountVisible = BaseSingleton<DashboardHelper>.Instance.IsAmountVisible;

            BaseSingleton<DashboardObserver>.Instance.HideAmount += OnHideAmount;

            SideMenuItems = BaseSingleton<SideMenuContainer>.Instance.BuildSideMenuItems();

            DisplayProfitPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ProfitPage));
        }

        private void OnHideAmount(object sender, Observers.DashboardArgs.HideAmountArgs e) {
            AmountVisible = !(e.IsHide);
            BaseSingleton<DashboardHelper>.Instance.IsAmountVisible = !(e.IsHide);
        }

        public void Dispose() {
            BaseSingleton<DashboardObserver>.Instance.HideAmount -= OnHideAmount;
        }
    }
}