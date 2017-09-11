using Tulsi.Controls;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content.AuditLogControls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuditLogMenuItem : StackListItemBase {
        public AuditLogMenuItem() {
            InitializeComponent();
        }

        public override void Deselected() {
        }

        public override void Selected() {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.AuditLogDetailsPage);
        }
    }
}