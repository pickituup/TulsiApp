using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.NavigationFramework.NavigationArgs;
using Tulsi.SharedService;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class ReportsIntermediatePageViewModel : ViewModelBase, IViewModel {

        string _title;
        public string Title {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        View _importedContent;
        public View ImportedContent {
            get { return _importedContent; }
            set { SetProperty(ref _importedContent, value); }
        }

        IView _importedView;
        public IView ImportedView {
            get { return _importedView; }
            set {
                if (SetProperty(ref _importedView, value) && value != null)
                    Spot.TranslateTo(0, 0);
            }
        }

        ContentView _spot;
        public ContentView Spot {
            get { return _spot; }
            set {
                if (SetProperty(ref _spot, value) && value != null)
                    HideSpotView();
            }
        }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        // Navigate to SearchPage.
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ReportsIntermediatePageViewModel() {
            BaseSingleton<NavigationObserver>.Instance.NavigatedContent += ImportingContent;

            BaseSingleton<NavigationObserver>.Instance.ImportedSpot += ImportingSpot;

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            BaseSingleton<NavigationObserver>.Instance.CloseView += OnCloseView;
        }

        private void OnCloseView(object sender, EventArgs e) {
            HideSpotView();
            ImportedView.Dispose();
            ImportedView = null;
        }

        public void NativeSenderCloseView() {
            HideSpotView();
            ImportedView.Dispose();
            ImportedView = null;
        }

        private void ImportingSpot(object sender, NavigationImportedEventArgs e) {
            ImportedView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType);
        }

        private void ImportingContent(object sender, NavigationImportedContentEventArgs e) {
            Title = e.Title;
            ImportedContent = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType) as View;
        }

        private void HideSpotView() {
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            Spot.TranslationY = displayHeight;
        }

        public void Dispose() {
            if (ImportedView != null) {
                ImportedView.Dispose();
            }

            BaseSingleton<NavigationObserver>.Instance.NavigatedContent -= ImportingContent;

            BaseSingleton<NavigationObserver>.Instance.ImportedSpot -= ImportingSpot;

            BaseSingleton<NavigationObserver>.Instance.CloseView -= OnCloseView;
        }

        public void ReSubscribe() {
            
        }
    }
}
