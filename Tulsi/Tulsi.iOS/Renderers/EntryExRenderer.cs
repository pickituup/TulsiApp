using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Tulsi.iOS.Renderers;
using Tulsi.Controls;

[assembly: ExportRenderer(typeof(EntryEx), typeof(EntryExRenderer))]
namespace Tulsi.iOS.Renderers {
    public sealed class EntryExRenderer : EntryRenderer {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);

            if (Control != null) {
                DisableNativeBorder();
            }

            if (e.OldElement != null) {
                // Unsubscribe from event handlers and cleanup any resources
            }

            if (e.NewElement != null) {
                // Configure the control and subscribe to event handlers
            }
        }

        /// <summary>
        /// Simply disables border of native entry
        /// </summary>
        private void DisableNativeBorder() {
            Control.BorderStyle = UIKit.UITextBorderStyle.None;
        }
    }
}