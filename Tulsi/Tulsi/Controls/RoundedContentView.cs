using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Tulsi.Controls
{
    public class RoundedContentView : ContentView
    {
        public static readonly BindableProperty CornerRaidusProperty =
#pragma warning disable CS0618 // Type or member is obsolete
          BindableProperty.Create<RoundedContentView, float>(x => x.CornerRadius, 0);
#pragma warning restore CS0618 // Type or member is obsolete

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRaidusProperty); }
            set { SetValue(CornerRaidusProperty, value); }
        }
    }
}
