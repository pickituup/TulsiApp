using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System;
using System.Threading.Tasks;

namespace Tulsi.NavigationFramework {
    public sealed class ViewSwitchingLogic {

        private static readonly string ERROR_NAVIGATION_STACK_IS_EMPTY = "Make shure that the current navigation stack is not empty";

        private static readonly string ERROR_INVALID_PAGE_IN_NAVIGATION_STACK = "Page must implement Tulsi.NavigationFramework.IView interface.";

        private readonly ViewContainer _viewContainer;

        /// <summary>
        ///     ctor().
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
            } else {
                ApplyVisualChangesWhileNavigating(Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault());
                PushPage(pageToPush);
            }
        }

        /// <summary>
        ///     Removes the last page from navigation stack. Root page will not be exclude from navigation stack. 
        /// </summary>
        public async void NavigateOneStepBack() {
            await Application.Current.MainPage.Navigation.PopAsync(false);

            ActionAfterNavigatedBackAsync(Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault());
        }

        private void ActionAfterNavigatedBackAsync(Page page) {
            if (page is IView) {
                ((IView)page).ReSubscribe();
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
        ///     PageToGoTo must be also setted in navigation stack.
        ///     Pages which goes after 'pageToGoTo' simply will be poped without animations.
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
                await Application.Current.MainPage.Navigation.PopAsync(false);
            }
        }

        /// <summary>
        ///     Pushes 'pageToPush' to the Navigation stack.
        /// </summary>
        /// <param name="targetPage"></param>
        private async void PushPage(Page pageToPush) {
            await Application.Current.MainPage.Navigation.PushAsync(pageToPush);
        }

        /// <summary>
        ///     Force to make 'navigation' visual changes for target page.
        /// </summary>
        private void ApplyVisualChangesWhileNavigating(Page targetPage) {
            try {
                ((IView)targetPage).ApplyVisualChangesWhileNavigating();
                ((IView)targetPage).Dispose();
            } catch (NullReferenceException exc) {
                throw new InvalidOperationException(string.Format("ViewSwitchingLogic.ApplyVisualChangesWhileNavigating - {0}. Exception details - {1}",
                    ERROR_NAVIGATION_STACK_IS_EMPTY, exc.Message));
            } catch (Exception exc) {
                throw new InvalidOperationException(string.Format("ViewSwitchingLogic.ApplyVisualChangesWhileNavigating - {0}, Exception details - {1}",
                    ERROR_INVALID_PAGE_IN_NAVIGATION_STACK, exc.Message));
            }
        }
    }
}