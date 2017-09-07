using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Helpers;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels.Content {
    public sealed class ExpensesCarouselViewModel : ViewModelBase, IViewModel {

        public ObservableCollection<CarouselContent> Items { get; set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ExpensesCarouselViewModel() {

            Items = new ObservableCollection<CarouselContent>() {
                new CarouselContent {
                    Id =1,
                    CurrentContent = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(ViewType.ExpensesView) as ContentView
                },
                new CarouselContent {
                    Id =2,
                    CurrentContent = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(ViewType.ExpensesListView) as ContentView
                },
            };
        }

        public void Dispose() {
            Items.Clear();
        }
    }
}
