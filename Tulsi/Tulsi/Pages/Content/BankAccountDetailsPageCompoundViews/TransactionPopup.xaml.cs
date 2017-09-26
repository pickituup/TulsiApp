using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Tulsi.Pages.Content.BankAccountDetailsPageCompoundViews {
    public partial class TransactionPopup : ContentView {

        public static readonly BindableProperty PopupVisibilityProperty =
            BindableProperty.Create("PopupVisibility",
                typeof(bool),
                typeof(TransactionPopup),
                defaultValue: false,
                propertyChanged: PopupVisibilityChanged);

        /// <summary>
        /// 
        /// </summary>
        public TransactionPopup() {
            InitializeComponent();

            TogglePopupVisibilty();
        }

        /// <summary>
        /// 
        /// </summary>
        public bool PopupVisibility {
            get => (bool)GetValue(TransactionPopup.PopupVisibilityProperty);
            set => SetValue(TransactionPopup.PopupVisibilityProperty, value);
        }

        /// <summary>
        /// 
        /// </summary>
        private void TogglePopupVisibilty() {
            if (PopupVisibility) {
                ShowPopup();
                return;
            }

            HidePopup();
        }

        /// <summary>
        /// 
        /// </summary>
        private async void ShowPopup() {
            IsVisible = true;

            await _movableContentSpot_ContentView.TranslateTo(0, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        private async void HidePopup() {
            await _movableContentSpot_ContentView.TranslateTo(0, 1000);

            IsVisible = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bindable"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        private static void PopupVisibilityChanged(BindableObject bindable, object oldValue, object newValue) {
            TransactionPopup transactionPopup = (TransactionPopup)bindable;

            if (transactionPopup != null) {
                transactionPopup.TogglePopupVisibilty();
            }
        }
    }
}
