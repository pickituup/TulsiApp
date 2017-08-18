using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class DashboardViewModel : ViewModelBase, IViewModel {

        public List<ChartModel> ChartData { get; set; }

        public List<NewsModel> NewsData { get; set; }

        public ICommand DisplaySearchPageCommand { get; set; }


        /// <summary>
        ///     ctor().
        /// </summary>
        public DashboardViewModel() {
            ChartData = new List<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Over Due", Value = 5 },
                new ChartModel { Name = "Due", Value = 72 }
            };

           
            NewsData = new List<NewsModel>()
            {
                new NewsModel { Picture = "Picture", Header = "Boating to the island", Edited="Midified: date", Icon="Icon" },
                new NewsModel { Picture = "Picture", Header = "Cabana view", Edited="Midified: date", Icon="Icon" },
                new NewsModel { Picture = "Picture", Header = "Chelsea view", Edited="Midified: date", Icon="Icon" }
            };

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SettingsPage));
        }

        public void Dispose() {
            
        }
    }
    public class ChartModel {
        public string Name { get; set; }

        public double Value { get; set; }
    }
    public class NewsModel {
        public string Picture { get; set; }

        public string Header { get; set; }

        public string Edited { get; set; }

        public string Icon { get; set; }
    }
    
}
