﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;

namespace Tulsi {
    public partial class SearchPage : ContentPage, IView {

        private readonly SearchPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public SearchPage() {
            InitializeComponent();

            BindingContext = _viewModel = new SearchPageViewModel();
        }

        /// <summary>
        ///     Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
