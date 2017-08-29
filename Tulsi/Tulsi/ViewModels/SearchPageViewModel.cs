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

        private ObservableCollection<ContactGroup> _contactsGroupsResult;

        /// <summary>
        ///     Public ctor().
        /// </summary>
        public SearchPageViewModel() {
            ClosePageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            ContactsGroupsResult = new ObservableCollection<ContactGroup>();

            HARDCODED_DATA_INSERT();
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ClosePageCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<ContactGroup> ContactsGroupsResult {
            get => _contactsGroupsResult;
            private set => SetProperty<ObservableCollection<ContactGroup>>(ref _contactsGroupsResult, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {

        }

        /// <summary>
        /// 
        /// </summary>
        private void HARDCODED_DATA_INSERT() {
            ContactGroup contactGroup = new ContactGroup();
            contactGroup.FirstLetter = "P";
            contactGroup.Add(new Contact() { Name = "Petro", Number = 122, Company = "Rlrrlrll lrll", IsOverDue = true, OverdueDays = 7 });
            contactGroup.Add(new Contact() { Name = "Phill", Number = 132, Company = "Rlrrlrll lrll" });
            contactGroup.Add(new Contact() { Name = "Petruha", Number = 77, Company = "Rlrrlrll lrll", IsOverDue = true, OverdueDays = 2 });

            ContactGroup contactGroup2 = new ContactGroup();
            contactGroup2.FirstLetter = "M";
            contactGroup2.Add(new Contact() { Name = "Mykola", Number = 234, Company = "Rlrrlrll lrll" });
            contactGroup2.Add(new Contact() { Name = "Mitya", Number = 56, Company = "Rlrrlrll lrll", IsOverDue = true, OverdueDays = 13 });
            contactGroup2.Add(new Contact() { Name = "Maha", Number = 788, Company = "Rlrrlrll lrll", IsOverDue = true, OverdueDays = 8 });
            contactGroup2.Add(new Contact() { Name = "Misha", Number = 213, Company = "Rlrrlrll lrll" });

            ContactGroup contactGroup3 = new ContactGroup();
            contactGroup3.FirstLetter = "A";
            contactGroup3.Add(new Contact() { Name = "Anzela", Number = 737, Company = "Rlrrlrll lrll" });
            contactGroup3.Add(new Contact() { Name = "Arnold", Number = 7237, Company = "Rlrrlrll lrll", IsOverDue = true, OverdueDays = 7 });
            contactGroup3.Add(new Contact() { Name = "Anatatoli", Number = 77, Company = "Rlrrlrll lrll" });

            ContactGroup contactGroup4 = new ContactGroup();
            contactGroup4.FirstLetter = "B";
            contactGroup4.Add(new Contact() { Name = "Bull", Number = 657, Company = "Rlrrlrll lrll" });
            contactGroup4.Add(new Contact() { Name = "Bird", Number = 34, Company = "Rlrrlrll lrll" });
            contactGroup4.Add(new Contact() { Name = "Baryg", Number = 87, Company = "Rlrrlrll lrll" });
            contactGroup4.Add(new Contact() { Name = "Bif", Number = 77, Company = "Rlrrlrll lrll" });

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
    }
}
