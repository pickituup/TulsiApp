using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Tulsi
{
    public partial class PasscodePage : ContentPage
    {
        public PasscodePage()
        {
            InitializeComponent();

            PasscodeEnter.Source = ImageSource.FromResource("Tulsi.Images.tick.png");
            PasscodeCancel.Source = ImageSource.FromResource("Tulsi.Images.cancel.png");
            ShieldLogo.Source = ImageSource.FromResource("Tulsi.Images.shield.png");
        }
    }
}
