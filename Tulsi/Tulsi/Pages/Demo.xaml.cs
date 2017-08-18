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
    }
}
