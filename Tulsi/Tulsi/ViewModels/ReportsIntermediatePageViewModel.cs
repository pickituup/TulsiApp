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
using Tulsi.ViewModels.Content;
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
                    Spot.TranslateTo(0, 0, 500);
            }
        }

        ContentView _spot;
        public ContentView Spot {
            get { return _spot; }
            set {
                if (SetProperty(ref _spot, value) && value != null)
                    HideView();
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

            BaseSingleton<NavigationObserver>.Instance.GrowerViewImportedSpot += GrowerViewImportingSpot;

            BaseSingleton<NavigationObserver>.Instance.BayerViewImportedSpot += OnBayerViewImportedSpot;

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        private void OnBayerViewImportedSpot(object sender, NavigationImportedEventArgs e) {
            ImportedView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType);
        }

        private void GrowerViewImportingSpot(object sender, NavigationImportedEventArgs e) {
            ImportedView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType);
        }

        private void ImportingContent(object sender, NavigationImportedContentEventArgs e) {
            Title = e.Title;
            ImportedContent = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType) as View;
        }

        public async void CloseImportedView() {
            if (this.ImportedView != null) {
                await HideViewAsync();
                ImportedView.Dispose();
                ImportedView = null;
            }
        }

        public void NativeSenderCloseView() {
            CloseImportedView();
        }

        private async void HideView() => await HideViewAsync();

        private async Task HideViewAsync() {
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            await Spot.TranslateTo(0, displayHeight, 700);
        }

        public void Dispose() {
            if (ImportedView != null) {
                ImportedView.Dispose();
            }

            if (ImportedContent !=null) {
                ((IView)ImportedContent).Dispose();
            }

            BaseSingleton<NavigationObserver>.Instance.NavigatedContent -= ImportingContent;
            BaseSingleton<NavigationObserver>.Instance.GrowerViewImportedSpot -= GrowerViewImportingSpot;
            BaseSingleton<NavigationObserver>.Instance.BayerViewImportedSpot -= OnBayerViewImportedSpot;
        }
    }
}
