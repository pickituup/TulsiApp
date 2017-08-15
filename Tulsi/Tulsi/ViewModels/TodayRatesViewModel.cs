using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class TodayRatesViewModel
    {
        public ObservableCollection<TodayRatesEntry> TodayRatesData { get; set; }
        public TodayRatesViewModel()
        {
            TodayRatesData = new ObservableCollection<TodayRatesEntry>()
            {
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "24D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "32D", Number = "140" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "42D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "45D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "54D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "60D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "72D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "84D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "96D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "108D", Number = "160" },
            /*    new TodayRatesEntry { GroupName = "Zakhir", Code = "24D", Number = "160" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "32D", Number = "140" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "42D", Number = "160" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "45D", Number = "160" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "54D", Number = "160" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "60D", Number = "160" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "72D", Number = "160" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "84D", Number = "160" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "96D", Number = "160" },
                new TodayRatesEntry { GroupName = "Zakhir", Code = "108D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "24D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "32D", Number = "140" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "42D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "45D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "54D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "60D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "72D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "84D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "96D", Number = "160" },
                new TodayRatesEntry { GroupName = "SuperSK (P)", Code = "108D", Number = "160" }*/
            };
        }
    }
    public class TodayRatesEntry : INotifyPropertyChanged
    {
        private string groupName;
        private string code;
        private string number;
        public string GroupName
        {
            get
            {
                return groupName;
            }
            set
            {
                groupName = value;
                OnPropertyChanged("GroupName");
            }
        }
        public string Code
        {
            get
            {
                return code;
            }
            set
            {
                code = value;
                OnPropertyChanged("Code");
            }
        }
        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
                OnPropertyChanged("Number");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

    }
}
