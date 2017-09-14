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
            Page relativePageFromNavigationStack =
                Application.Current.MainPage.Navigation.NavigationStack.FirstOrDefault(p =>
                    p.GetType().Name == viewType.ToString());

            if (relativePageFromNavigationStack != null) {
                MoveToTheExistingPageInNavigationStack(relativePageFromNavigationStack);
            } else {
                ApplyVisualChangesWhileNavigating(Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault());
                PushPage((Page)_viewContainer.GetViewByType(viewType));
            }
        }

        /// <summary>
        ///     Removes the last page from navigation stack. Root page will not be exclude from navigation stack. 
        /// </summary>
        public async void NavigateOneStepBack() {
            DisposeBeforeNavigate(Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault());

            await Application.Current.MainPage.Navigation.PopAsync(false);
        }

        private void DisposeBeforeNavigate(Page page) {
            if (page is IView) {
                ((IView)page).Dispose();

                GC.Collect();
            }
        }

        /// <summary>
        ///     After navigate back Can do something.
        /// </summary>
        /// <param name="page"></param>
        private void ActionAfterNavigatedBackAsync(Page page) {
            if (page is IView) {
                // Can do something.
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
            if (Application.Current.MainPage != null) {
                DisposeBeforeNavigate(Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault());
            }

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
                DisposeBeforeNavigate(Application.Current.MainPage.Navigation.NavigationStack.LastOrDefault());
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
            } catch (NullReferenceException exc) {
                throw new InvalidOperationException(string.Format($"ViewSwitchingLogic.ApplyVisualChangesWhileNavigating -                  {ERROR_NAVIGATION_STACK_IS_EMPTY}. Exception details - {exc.Message}"));
            } catch (Exception exc) {
                throw new InvalidOperationException(string.Format($"ViewSwitchingLogic.ApplyVisualChangesWhileNavigating - {ERROR_INVALID_PAGE_IN_NAVIGATION_STACK}, Exception details - {exc.Message}"));
            }
        }
    }
}