using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Tulsi.NavigationFramework {
    public sealed class ViewSwitchingLogic {
        private readonly ViewContainer _viewContainer;

        /// <summary>
        ///     Public ctor
        /// </summary>
        public ViewSwitchingLogic() {
            _viewContainer = new ViewContainer();
        }

        /// <summary>
        ///     Creates new navigation stack. Root element will be appropriate to the viewType.
        /// </summary>
        public void BuildNavigationStack(ViewType viewType) {
            Application.Current.MainPage = GetViewInNavigationFrameByType(viewType);
        }

        /// <summary>
        ///     Navigate by ViewType.
        /// </summary>
        public void NavigateTo(ViewType viewType) {
            Page pageToPush = (Page)_viewContainer.GetViewByType(viewType);

            Page relativePageFromNavigationStack =
                Application.Current.MainPage.Navigation.NavigationStack
                .FirstOrDefault(p => p.GetType() == pageToPush.GetType());

            if (relativePageFromNavigationStack != null) {
                MoveToTheExistingPageInNavigationStack(relativePageFromNavigationStack);
            }
            else {
                PushPage(pageToPush);
            }
        }

        /// <summary>
        ///     Get view of the appropriate type
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        public IView GetViewByType(ViewType viewType) {
            return _viewContainer.GetViewByType(viewType);
        }

        /// <summary>
        ///     Get view of the appropriate type wrapped by Xamarin.Forms.NavigationPage
        /// </summary>
        /// <param name="viewType"></param>
        /// <returns></returns>
        private Page GetViewInNavigationFrameByType(ViewType viewType) {
            return _viewContainer.GetViewInNavigationFrameByType(viewType);
        }

        /// <summary>
        /// PageToGoTo must be also setted in navigation stack.
        /// Pages which goes after 'pageToGoTo' simply will be poped without animations.
        /// </summary>
        /// <param name="pageToGoTo"></param>
        private async void MoveToTheExistingPageInNavigationStack(Page pageToGoTo) {
            List<Page> pagesToLeaveInStack = new List<Page>();

            foreach (Page page in Application.Current.MainPage.Navigation.NavigationStack) {
                pagesToLeaveInStack.Add(page);

                if (page.Equals(pageToGoTo)) {
                    break;
                }
            }

            int timesToPop = Application.Current.MainPage.Navigation.NavigationStack
                .Except(pagesToLeaveInStack).Count();

            for (int i = 0; i < timesToPop; i++) {
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        /// <summary>
        /// Pushes 'pageToPush' to the Navigation stack.
        /// </summary>
        /// <param name="targetPage"></param>
        private async void PushPage(Page pageToPush) {
            await Application.Current.MainPage.Navigation.PushAsync(pageToPush);
        }
    }
}