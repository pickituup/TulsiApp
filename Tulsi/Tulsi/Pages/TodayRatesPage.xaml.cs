using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using Xamarin.Forms;
using Tulsi.ViewModels;
using Syncfusion.DataSource;
using SlideOverKit;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;
using System.Collections;
using Tulsi.Controls.TodayRatesControls;

namespace Tulsi {
    public partial class TodayRatesPage : MenuContainerPage, IView {
        private readonly TodayRatesViewModel _viewModel;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public TodayRatesPage() {
            InitializeComponent();
            
            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new TodayRatesViewModel();

            //
            // TODO: unsubscribe from current event.
            //
            _viewModel.TodayRatesData.CollectionChanged += TodayRatesDataCollectionChanged;

            InitialiseExpandedGroupItem(_viewModel.TodayRatesData);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TodayRatesDataCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            //
            // TODO: handle other observable collection Actions
            //
            if (e.Action == NotifyCollectionChangedAction.Add) {
                InitialiseExpandedGroupItem(e.NewItems);
            }
        }

        /// <summary>
        /// TODO: define some factoy or ControlContainer that will create that ExpandedGroup...
        /// </summary>
        /// <param name="newItems"></param>
        private void InitialiseExpandedGroupItem(IList newItems) {
            foreach (object item in newItems) {
                ExpandedGroup expandedGroup = new ExpandedGroup();
                expandedGroup.BindingContext = item;

                _ratesStack_StackLayout.Children.Add(expandedGroup);
            }
        }
    }
}
