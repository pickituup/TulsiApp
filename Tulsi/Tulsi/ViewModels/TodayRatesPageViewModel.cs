using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class TodayRatesPageViewModel : ViewModelBase, IViewModel {

        private int _currentIndex = default(int);

        private List<TodayRatesDataCollection> _tempList;

        DateTime _currentDate;
        public DateTime CurrentDate {
            get { return _currentDate; }
            set { SetProperty(ref _currentDate, value); }
        }

        ObservableCollection<TodayRatesEntry> _todayRatesData;
        public ObservableCollection<TodayRatesEntry> TodayRatesData {
            get { return _todayRatesData; }
            set { SetProperty(ref _todayRatesData, value); }
        }

        public ICommand PreviousListCommand { get; private set; }

        public ICommand NextListCommand { get; private set; }

        // Navigates to search page
        public ICommand DisplaySearchPageCommand { get; private set; }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public TodayRatesPageViewModel() {
            InitilizeTodayRatesDataCollection();

            PreviousListCommand = new Command(GetPreviousList);

            NextListCommand = new Command(GetNextList);

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            TodayRatesData = GetTodayRatesData();

            CurrentDate = _tempList[_currentIndex].Date;
        }

        private void GetNextList(object obj) {
            if (_currentIndex != _tempList.Count - 1) {
                _currentIndex++;

                TodayRatesData = new ObservableCollection<TodayRatesEntry>(_tempList[_currentIndex].TodayRates);
                CurrentDate = _tempList[_currentIndex].Date;
            }
        }

        private void GetPreviousList(object obj) {
            if (_currentIndex != 0) {
                _currentIndex--;

                TodayRatesData = new ObservableCollection<TodayRatesEntry>(_tempList[_currentIndex].TodayRates);
                CurrentDate = _tempList[_currentIndex].Date;
            }
        }

        private void InitilizeTodayRatesDataCollection() {
            _tempList = new List<TodayRatesDataCollection>() {
                new TodayRatesDataCollection() {
                    Date = new DateTime(2016, 05, 15),
                    TodayRates = new List<TodayRatesEntry> {
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Wahe Guru",
                        Sum = 667
                    },
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Wahe Guru",
                        Sum = 555
                    },
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Guru",
                        Sum = 777
                    }
                    }
                },
                new TodayRatesDataCollection() {
                    Date = new DateTime(2017, 11, 22),
                    TodayRates = new List<TodayRatesEntry> {
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Wahe Guru",
                        Sum = 667
                    },
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Wahe Guru",
                        Sum = 555
                    },
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Wahe Guru",
                        Sum = 667
                    },
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Wahe Guru",
                        Sum = 555
                    },
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Guru",
                        Sum = 777
                    }
                    }
                },
                new TodayRatesDataCollection() {
                    Date = new DateTime(2017, 12, 07),
                    TodayRates = new List<TodayRatesEntry> {
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Wahe Guru",
                        Sum = 667
                    },
                        new TodayRatesEntry {
                        Date = DateTime.Now,
                        Items = new List<TodayRatesSubItem> {
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            },
                            new TodayRatesSubItem {
                                Code = "240",
                                Number = 160
                            }
                        },
                        GroupName = "Guru",
                        Sum = 777
                    }
                    }
                }
            };
        }

        private ObservableCollection<TodayRatesEntry> GetTodayRatesData() {
            return new ObservableCollection<TodayRatesEntry>(_tempList.FirstOrDefault().TodayRates);
        }

        private void HARDCODED_DATA_INSERT() {
            Random random = new Random();

            for (int i = 0; i < 4; i++) {
                TodayRatesEntry todayRatesEntry = new TodayRatesEntry() {
                    GroupName = "Wahe Guru",
                    Sum = 667
                };

                int randomNumber = random.Next(1, 9);
                for (int y = 0; y < randomNumber; y++) {
                    todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                }

                TodayRatesData.Add(todayRatesEntry);
            }
        }

        public void Dispose() {
            _tempList.Clear();
            _todayRatesData.Clear();
        }
    }
}
