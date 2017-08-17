using Xamarin.Forms;

namespace Tulsi.NavigationFramework {
    public sealed class ViewSwitchingLogic {
        private readonly ViewContainer _viewContainer;

        /// <summary>
        /// Public ctor
        /// </summary>
        public ViewSwitchingLogic() {
            _viewContainer = new ViewContainer();
        }

        /// <summary>
        /// Creates new navigation stack. Root element will be appropriate to the viewType.
        /// </summary>
        public void BuildNavigationStack(ViewType viewType) {
            Application.Current.MainPage = GetViewInNavigationFrameByType(viewType);
        }

        /// <summary>
        /// 
        /// </summary>
        public async void NavigateTo(ViewType viewType) {
            //
            // TODO: check if the view from the TOP of navigation stack equal to the required viewType
            // (return, and just keep displaing that view)
            //

            await Application.Current.MainPage.Navigation.PopToRootAsync();
            await Application.Current.MainPage.Navigation.PushAsync((Page)_viewContainer.GetViewByType(viewType));
        }

        /// <summary>
        /// Get view of the appropriate type
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        private IView GetViewByType(ViewType viewType) {
            return _viewContainer.GetViewByType(viewType);
        }

        /// <summary>
        /// Get view of the appropriate type wrapped by Xamarin.Forms.NavigationPage
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        private Page GetViewInNavigationFrameByType(ViewType viewType) {
            return _viewContainer.GetViewInNavigationFrameByType(viewType);
        }
    }
}