using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrowerProfileView : ContentView, IView {

        /// <summary>
        ///     ctor().
        /// </summary>
        public GrowerProfileView() {
            InitializeComponent();
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }
    }
}