using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Tulsi.ViewModels;

namespace Tulsi
{
    public partial class GrowerProfilePage : ContentPage
    {
        public GrowerProfilePage()
        {
            InitializeComponent();

            ProfileViewModel pvm = new ProfileViewModel();
            ProfileTransactionsListView.ItemsSource = pvm.TransactionsData;
            ProfileTransactionsListView.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            TapGestureRecognizer CloseTap = new TapGestureRecognizer();
            CloseTap.Tapped += (s, e) =>
            {
                Application.Current.MainPage.Navigation.PopAsync();
            };
            Close.GestureRecognizers.Add(CloseTap);

        }
    }
}
