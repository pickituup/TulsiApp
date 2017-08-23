using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Tulsi.Controls.TodayRatesControls {
    public partial class ExpandedGroup : ContentView {
        /// <summary>
        /// Public ctor.
        /// </summary>
        public ExpandedGroup() {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GroupHeaderTapped(object sender, EventArgs e) {
            _itemsList_ListView.IsVisible = !(_itemsList_ListView.IsVisible);
        }

        /// <summary>
        /// Simly deselects selection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onItemSelected(object sender, SelectedItemChangedEventArgs e) {
            ((ListView)sender).SelectedItem = null;
        }
    }
}