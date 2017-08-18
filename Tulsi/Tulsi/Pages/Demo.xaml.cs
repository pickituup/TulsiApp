using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Demo : PageWithSideMenuBase {
        public Demo() {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e) {
            ShowMenu();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e) {

        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e) {

        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {

        }
    }
}
