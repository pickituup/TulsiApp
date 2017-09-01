using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Tulsi.Helpers;
using System.Linq;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.Model;

namespace Tulsi.ViewModels {
    public class SearchPageViewModel : ViewModelBase, IViewModel {

        ObservableCollection<ContactGroup> _contactsGroupsResult;
        public ObservableCollection<ContactGroup> ContactsGroupsResult {
            get => _contactsGroupsResult;
            private set => SetProperty<ObservableCollection<ContactGroup>>(ref _contactsGroupsResult, value);
        }

        public ICommand ClosePageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public SearchPageViewModel() {
            ClosePageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            ContactsGroupsResult = new ObservableCollection<ContactGroup>();

            HARDCODED_DATA_INSERT();
        }

        private void HARDCODED_DATA_INSERT() {
            ContactGroup contactGroup = new ContactGroup();
            contactGroup.FirstLetter = "P";
            contactGroup.Add(new Contact() {
                ContactProgressColor = Color.Yellow,
                ContactProgress = .2,
                Name = "Petro",
                Number = 122,
                Company = "Rlrrlrll lrll",
                IsOverDue = true,
                OverdueDays = 7
            });
            contactGroup.Add(new Contact() {
                ContactProgressColor = Color.FromHex("#2793F5"),
                ContactProgress = .35,
                Name = "Phill",
                Number = 132,
                Company = "Rlrrlrll lrll"
            });
            contactGroup.Add(new Contact() {
                ContactProgressColor = Color.Red,
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
                ContactProgressColor = Color.FromHex("#2793F5"),
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
                ContactProgressColor = Color.Red,
                ContactProgress = .1,
                Name = "Maha",
                Number = 788,
                Company = "Rlrrlrll lrll",
                IsOverDue = true,
                OverdueDays = 8
            });
            contactGroup2.Add(new Contact() {
                ContactProgressColor = Color.Yellow,
                ContactProgress = .4,
                Name = "Misha",
                Number = 213,
                Company = "Rlrrlrll lrll"
            });

            ContactGroup contactGroup3 = new ContactGroup();
            contactGroup3.FirstLetter = "A";
            contactGroup3.Add(new Contact() {
                ContactProgressColor = Color.FromHex("#2793F5"),
                ContactProgress = .66,
                Name = "Anzela",
                Number = 737,
                Company = "Rlrrlrll lrll"
            });
            contactGroup3.Add(new Contact() {
                ContactProgressColor = Color.FromHex("#2793F5"),
                ContactProgress = .95,
                Name = "Arnold",
                Number = 7237,
                Company = "Rlrrlrll lrll",
                IsOverDue = true,
                OverdueDays = 7
            });
            contactGroup3.Add(new Contact() {
                ContactProgressColor = Color.FromHex("#2793F5"),
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
                ContactProgressColor = Color.Yellow,
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
                    groups.OrderBy<ContactGroup, string>((c) => c.FirstLetter)
                    .ToList<ContactGroup>());
        }

        public void Dispose() {
            ContactsGroupsResult.Clear();
        }
    }
}
