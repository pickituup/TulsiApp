using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class ProfilePage : ContentPage, IView {
        private ProfilePageViewModel _viewModel;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public ProfilePage() {
            InitializeComponent();

            BindingContext = _viewModel = new ProfilePageViewModel();
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() { }
    }
}