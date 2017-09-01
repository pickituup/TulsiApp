using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Xamarin.Forms.Xaml;

namespace Tulsi.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuItemView : StackListItemBase {
        public MenuItemView() {
            InitializeComponent();
        }

        public override void Deselected() {
            
        }

        public override void Selected() {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.AuditLogDetailsPage);
        }
    }
}