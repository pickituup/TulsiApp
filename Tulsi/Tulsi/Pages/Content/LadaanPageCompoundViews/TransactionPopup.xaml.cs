using Xamarin.Forms;

namespace Tulsi.Pages.Content.LadaanPageCompoundViews {
    public partial class TransactionPopup : ContentView {

        public static readonly BindableProperty PopupVisibilityProperty =
            BindableProperty.Create("PopupVisibility",
                typeof(bool),
                typeof(TransactionPopup),
                defaultValue: false,
                propertyChanged: PopupVisibilityChanged);

        public bool PopupVisibility {
            get => (bool)GetValue(PopupVisibilityProperty);
            set => SetValue(PopupVisibilityProperty, value);
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public TransactionPopup() {
            InitializeComponent();
            
            TogglePopupVisibilty();
        }

        private void TogglePopupVisibilty() {
            if (PopupVisibility) {
                ShowPopup();
                return;
            }

            HidePopup();
        }

        private async void ShowPopup() {
            IsVisible = true;

            await _movableContentSpot_ContentView.TranslateTo(0, 0);
        }

        private async void HidePopup() {
            await _movableContentSpot_ContentView.TranslateTo(0, 1000);

            IsVisible = false;
        }

        private static void PopupVisibilityChanged(BindableObject bindable, object oldValue, object newValue) {
            TransactionPopup transactionPopup = (TransactionPopup)bindable;

            if (transactionPopup!= null) {
                transactionPopup.TogglePopupVisibilty();
            }
        }
    }
}