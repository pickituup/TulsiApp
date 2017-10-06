using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model;
using Tulsi.Model.DataContainers;
using Tulsi.Model.DataContainers.DataItems;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels.Content {
    public sealed class ArrivalViewModel : ViewModelBase, IViewModel {

        DateTime _selectedDate;
        public DateTime SelectedDate {
            get { return _selectedDate; }
            set { SetProperty(ref _selectedDate, value); }
        }

        ObservableCollection<ArrivalTransaction> _arrivalItems;
        public ObservableCollection<ArrivalTransaction> ArrivalItems {
            get { return _arrivalItems; }
            set { SetProperty(ref _arrivalItems, value); }
        }

        ArrivalItem _selectedMenuItem;
        public ArrivalItem SelectedItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {
                    BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ArrivalDetailsPage);
                }
            }
        }

        ObservableCollection<ArrivalItem> _selectionTransactions;
        public ObservableCollection<ArrivalItem> SelectionTransactions {
            get { return _selectionTransactions; }
            set { SetProperty(ref _selectionTransactions, value); }
        }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ArrivalViewModel() {
            SelectedDate = DateTime.Now;

            ArrivalItems = GetArrivalItems();

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        private ObservableCollection<ArrivalTransaction> GetArrivalItems() {
            return new ObservableCollection<ArrivalTransaction>() {
                new ArrivalTransaction {
                    Date = new DateTime(2017, 10, 01),
                    ArrivalTransactions = new List<ArrivalItem>() {
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                }
                    }
                },
                new ArrivalTransaction {
                    Date = new DateTime(2017, 10, 08),
                    ArrivalTransactions = new List<ArrivalItem>() {
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                }
                    }
                },
                new ArrivalTransaction {
                    Date = new DateTime(2017, 10, 15),
                    ArrivalTransactions = new List<ArrivalItem>() {
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                }
                    }
                },
                new ArrivalTransaction {
                    Date = new DateTime(2017, 10, 01),
                    ArrivalTransactions = new List<ArrivalItem>() {
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                }
                    }
                },
                new ArrivalTransaction {
                    Date = new DateTime(2017, 10, 18),
                    ArrivalTransactions = new List<ArrivalItem>() {
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                }
                    }
                },
                new ArrivalTransaction {
                    Date = new DateTime(2017, 10, 27),
                    ArrivalTransactions = new List<ArrivalItem>() {
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value = 100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                                        return stream; })
                        },
                        new ArrivalItem {
                                Title = "PSO Orch",
                                Value =  100.110m,
                                Number="280",
                                Icon =ImageSource.FromStream(()=> {
                                        Assembly assembly = GetType().GetTypeInfo().Assembly;
                                        Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                                        return stream; })
                }
                    }
                }
            };
        }

        internal void GetSelectionTransaction(DateTime dateTime) {
            SelectedDate = dateTime;

            if (ArrivalItems != null) {
                var tt = (from item in ArrivalItems
                         where item.Date == dateTime
                         select item.ArrivalTransactions).ToList();

                if (tt.Count > 0) {
                    SelectionTransactions = new ObservableCollection<ArrivalItem>(tt.FirstOrDefault());
                } else
                    SelectionTransactions = new ObservableCollection<ArrivalItem>();
            }
        }

        public void Dispose() {
            ArrivalItems?.Clear();

            SelectionTransactions?.Clear();
        }
    }
}

