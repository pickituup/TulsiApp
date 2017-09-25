using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tulsi.Helpers;
using System.Linq;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.Model;
using Tulsi.SharedService;
using Tulsi.NavigationFramework.NavigationArgs;
using System;
using System.Threading.Tasks;

namespace Tulsi.ViewModels {
    public class SearchPageViewModel : ViewModelBase, IViewModel {

        IView _importedView;
        public IView ImportedView {
            get { return _importedView; }
            set {
                if (SetProperty(ref _importedView, value) && value != null)
                    Spot.TranslateTo(0, 0, 700);
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

        Contact _selectedItem;
        public Contact SelectedItem {
            get => _selectedItem;
            set {
                if (SetProperty<Contact>(ref _selectedItem, value) && value != null) {
                    BaseSingleton<NavigationObserver>.Instance.OnSearchImportedSpot(ViewType.BuyerProfileView);
                    //BaseSingleton<NavigationObserver>.Instance.OnSendToBuyerProfileTransAction(value.ProfileTransactions);

                    SelectedItem = null;
                }
            }
        }

        ObservableCollection<Contact> _testList;
        public ObservableCollection<Contact> TestList {
            get { return _testList; }
            set { SetProperty(ref _testList, value); }
        }

        ObservableCollection<ContactGroup> _contactsGroupsResult;
        public ObservableCollection<ContactGroup> ContactsGroupsResult {
            get => _contactsGroupsResult;
            private set => SetProperty(ref _contactsGroupsResult, value);
        }

        public ICommand ClosePageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public SearchPageViewModel() {
            BaseSingleton<NavigationObserver>.Instance.SearchImportedSpot += ImportingSpot;

            ClosePageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            ContactsGroupsResult = new ObservableCollection<ContactGroup>();

            HARDCODED_DATA_INSERT();
        }

        private void ImportingSpot(object sender, NavigationImportedEventArgs e) {
            ImportedView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType);
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

        private void HARDCODED_DATA_INSERT() {
            ContactGroup contactGroup = new ContactGroup();
            contactGroup.FirstLetter = "P";
            contactGroup.Add(new Contact() {
                ContactProgress = .2,
                Name = "Petro",
                Number = 122,
                Company = "Rlrrlrll lrll",
                IsOverDue = true,
                OverdueDays = 7
            });
            contactGroup.Add(new Contact() {
                ContactProgress = .35,
                Name = "Phill",
                Number = 132,
                Company = "Rlrrlrll lrll"
            });
            contactGroup.Add(new Contact() {
                ContactProgress = .7,
                Name = "Petruha",
                Number = 77,
                Company = "Rlrrlrll lrll",
                IsOverDue = true,
                OverdueDays = 2
            });

            ContactGroup contactGroup2 = new ContactGroup();
            contactGroup2.FirstLetter = "M";
            contactGroup2.Add(new Contact() {
                ContactProgress = .5,
                Name = "Mykola",
                Number = 234,
                Company = "Rlrrlrll lrll"
            });
            contactGroup2.Add(new Contact() {
                ContactProgress = .8,
                Name = "Mitya",
                Number = 56,
                Company = "Rlrrlrll lrll",
                IsOverDue = true,
                OverdueDays = 13
            });
            contactGroup2.Add(new Contact() {
                ContactProgress = .1,
                Name = "Maha",
                Number = 788,
                Company = "Rlrrlrll lrll",
                IsOverDue = true,
                OverdueDays = 8
            });
            contactGroup2.Add(new Contact() {
                ContactProgress = .4,
                Name = "Misha",
                Number = 213,
                Company = "Rlrrlrll lrll"
            });

            ContactGroup contactGroup3 = new ContactGroup();
            contactGroup3.FirstLetter = "A";
            contactGroup3.Add(new Contact() {
                ContactProgress = .66,
                Name = "Anzela",
                Number = 737,
                Company = "Rlrrlrll lrll"
            });
            contactGroup3.Add(new Contact() {
                ContactProgress = .95,
                Name = "Arnold",
                Number = 7237,
                Company = "Rlrrlrll lrll",
                IsOverDue = true,
                OverdueDays = 7
            });
            contactGroup3.Add(new Contact() {
                ContactProgress = .15,
                Name = "Anatatoli",
                Number = 77,
                Company = "Rlrrlrll lrll"
            });

            ContactGroup contactGroup4 = new ContactGroup();
            contactGroup4.FirstLetter = "B";
            contactGroup4.Add(new Contact() {
                ContactProgress = .25,
                Name = "Bull",
                Number = 657,
                Company = "Rlrrlrll lrll"
            });
            contactGroup4.Add(new Contact() {
                ContactProgress = .75,
                Name = "Bird",
                Number = 34,
                Company = "Rlrrlrll lrll"
            });
            contactGroup4.Add(new Contact() {
                ContactProgress = .44,
                Name = "Baryg",
                Number = 87,
                Company = "Rlrrlrll lrll"
            });
            contactGroup4.Add(new Contact() {
                ContactProgress = .65,
                Name = "Bif",
                Number = 77,
                Company = "Rlrrlrll lrll"
            });

            List<ContactGroup> groups = new List<ContactGroup>();
            groups.Add(contactGroup);
            groups.Add(contactGroup2);
            groups.Add(contactGroup3);
            groups.Add(contactGroup4);

            //
            // Bad ass hardcoded implementation
            //
            ContactsGroupsResult =
                new ObservableCollection<ContactGroup>(
                    groups.OrderBy((c) => c.FirstLetter)
                    .ToList());

            //TestList = GetContactsGroupsResult();
        }

        private ObservableCollection<Contact> GetContactsGroupsResult() {
            List<Contact> orederedList = new List<Contact>
            {
                new Contact() {
                    ContactProgressColor = Color.Yellow,
                    ContactProgress = .2,
                    Name = "Petro",
                    Number = 122,
                    Company = "Rlrrlrll lrll",
                    IsOverDue = true,
                    OverdueDays = 7
                },
                new Contact() {
                    ContactProgressColor = Color.FromHex("#2793F5"),
                    ContactProgress = .35,
                    Name = "Phill",
                    Number = 132,
                    Company = "Rlrrlrll lrll"
                },
                new Contact() {
                    ContactProgressColor = Color.Red,
                    ContactProgress = .7,
                    Name = "Petruha",
                    Number = 77,
                    Company = "Rlrrlrll lrll",
                    IsOverDue = true,
                    OverdueDays = 2
                },
                new Contact {
                    ContactProgressColor = Color.FromHex("#2793F5"),
                    ContactProgress = .5,
                    Name = "Mykola",
                    Number = 234,
                    Company = "Rlrrlrll lrll"
                }
            };

            return new ObservableCollection<Contact>(orederedList.OrderBy((x) => x.Name));
        }

        public void Dispose() {
            if (ImportedView != null) {
                ImportedView.Dispose();
            }

            ContactsGroupsResult.Clear();

            BaseSingleton<NavigationObserver>.Instance.SearchImportedSpot -= ImportingSpot;
        }
    }
}
