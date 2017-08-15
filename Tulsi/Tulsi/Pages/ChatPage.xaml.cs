using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Tulsi
{
    public partial class ChatPage : ContentPage
    {
        public ChatPage()
        {
            InitializeComponent();
            
            Photo.Source = ImageSource.FromResource("Tulsi.Images.chatphoto.png");

            //Toolbar taps   //No menu for chat? Why?
            TapGestureRecognizer tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) =>
            {
                Application.Current.MainPage.Navigation.PopAsync();
            };
            Back.GestureRecognizers.Add(tapGestureRecognizer2);

            //Menu taps
            TapGestureRecognizer MenuTap1 = new TapGestureRecognizer();
            MenuTap1.Tapped += (s, e) =>
            {
                Application.Current.MainPage.Navigation.PopAsync();
            };
            Back.GestureRecognizers.Add(MenuTap1);

            Tick1.Source = ImageSource.FromResource("Tulsi.Images.chatgraytick.png");
            Tick2.Source = ImageSource.FromResource("Tulsi.Images.chatbluetick.png");
            Tick3.Source = ImageSource.FromResource("Tulsi.Images.chatgraytick.png");
            ChatAddImage.Source = ImageSource.FromResource("Tulsi.Images.camera.png");
        }
    }
}
