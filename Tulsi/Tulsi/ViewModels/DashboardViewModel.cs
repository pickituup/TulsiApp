using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class DashboardViewModel
    {
        public List<ChartModel> ChartData { get; set; }
        public List<NewsModel> NewsData { get; set; }
        public DashboardViewModel()
        {
            ChartData = new List<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Over Due", Value = 5 },
                new ChartModel { Name = "Due", Value = 72 }
            };

            /*NewsData = new List<NewsModel>()
            {
                new NewsModel { Picture = "Picture", Header = "Boating to the island", Edited="Midified: "+DateTime.Now.Date.ToString("MMMM d, yyyy"), Icon="Icon" },
                new NewsModel { Picture = "Picture", Header = "Cabana view", Edited="Midified: "+DateTime.Now.Date.ToString("MMMM d, yyyy"), Icon="Icon" },
                new NewsModel { Picture = "Picture", Header = "Chelsea view", Edited="Midified: "+DateTime.Now.Date.ToString("MMMM d, yyyy"), Icon="Icon" }
            };*/
            NewsData = new List<NewsModel>()
            {
                new NewsModel { Picture = "Picture", Header = "Boating to the island", Edited="Midified: date", Icon="Icon" },
                new NewsModel { Picture = "Picture", Header = "Cabana view", Edited="Midified: date", Icon="Icon" },
                new NewsModel { Picture = "Picture", Header = "Chelsea view", Edited="Midified: date", Icon="Icon" }
            };
        }
    }
    public class ChartModel
    {
        public string Name { get; set; }

        public double Value { get; set; }
    }
    public class NewsModel
    {
        public string Picture { get; set; }

        public string Header { get; set; }

        public string Edited { get; set; }

        public string Icon { get; set; }
    }
    public class SideMenuItem
    {
        public string Icon { get; set; }
        public string Title { get; set; }
    }
    static public class SideMenuList
    {
        static public List<SideMenuItem> Items = new List<SideMenuItem>
        {
            new SideMenuItem { Icon="Icon", Title="Buyer" },
            new SideMenuItem { Icon="Icon", Title="Grower" },
            new SideMenuItem { Icon="Icon", Title="Audit Log" },
            new SideMenuItem { Icon="Icon", Title="Report" },
            new SideMenuItem { Icon="Icon", Title="Chat" },
            new SideMenuItem { Icon="Icon", Title="Settings" },
            new SideMenuItem { Icon="Icon", Title="Me" },
        };
    }
}
