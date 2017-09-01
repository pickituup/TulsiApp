using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace Tulsi.Controls {
    public class AdvancedStackList : StackLayout {
        private static readonly string _ERORR_LAYOUT_FILLING = "Check validity of ItemsSource or ItemTemplate";

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource",
                typeof(IList),
                typeof(AdvancedStackList),
                propertyChanged: OnItemsSourceChanged);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate",
                typeof(DataTemplate),
                typeof(AdvancedStackList),
                propertyChanged: OnItemTemplateChanged);

        public static readonly BindableProperty GroupHeaderTemplateProperty =
            BindableProperty.Create("GroupHeaderTemplate",
                typeof(DataTemplate),
                typeof(AdvancedStackList),
                propertyChanged: OnGroupHeaderTemplateChanged);

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create("SelectedItem",
                typeof(object),
                typeof(AdvancedStackList));

        private StackListItemBase _selectedStackListItem;

        /// <summary>
        ///     ctor().
        /// </summary>
        public AdvancedStackList() {
            Spacing = 0;
            IsGrouped = false;
        }

        /// <summary>
        /// 
        /// </summary>
        public IList ItemsSource {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set {
                SetValue(ItemsSourceProperty, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsGrouped { get; set; }

        /// <summary>
        /// Use DataTemplate with StackListItem as root only.
        /// </summary>
        public DataTemplate ItemTemplate {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public DataTemplate GroupHeaderTemplate {
            get { return (DataTemplate)GetValue(GroupHeaderTemplateProperty); }
            set { SetValue(GroupHeaderTemplateProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public object SelectedItem {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="oldVal"></param>
        /// <param name="newVal"></param>
        private static void OnItemTemplateChanged(BindableObject obj, object oldVal, object newVal) {
            AdvancedStackList layout = obj as AdvancedStackList;

            if (layout != null && layout.ItemsSource != null) {
                layout.FillLayout();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="oldVal"></param>
        /// <param name="newVal"></param>
        private static void OnGroupHeaderTemplateChanged(BindableObject obj, object oldVal, object newVal) {
            AdvancedStackList layout = obj as AdvancedStackList;

            if (layout != null && layout.ItemsSource != null) {
                layout.FillLayout();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="oldVal"></param>
        /// <param name="newVal"></param>
        private static void OnItemsSourceChanged(BindableObject obj, object oldVal, object newVal) {
            AdvancedStackList layout = obj as AdvancedStackList;

            if (layout.ItemTemplate != null) {
                layout.FillLayout();

                if (newVal != null && newVal is INotifyCollectionChanged) {
                    //
                    // TODO: unsubscribe from the event when current
                    //
                    if (oldVal != null && oldVal is INotifyCollectionChanged) {
                        ((INotifyCollectionChanged)newVal).CollectionChanged -= layout.StackList_CollectionChanged;
                    }

                    ((INotifyCollectionChanged)newVal).CollectionChanged += layout.StackList_CollectionChanged;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StackList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.Action == NotifyCollectionChangedAction.Add) {
                if (IsGrouped) {
                    foreach (object group in e.NewItems) {
                        Children.Add(PrepareGroup(group));
                    }
                }
                else {
                    foreach (object item in e.NewItems) {
                        Children.Add(PrepareSingleItem(item));
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove) {
                foreach (object item in e.OldItems) {
                    View childToRemove = Children.FirstOrDefault(v => v.BindingContext == item);
                    Children.Remove(childToRemove);
                }
            }
            else {
                //
                // TODO: try to handle other actions...
                //
                throw new NotImplementedException("StackList.StackList_CollectionChanged");
            }
        }

        /// <summary>
        /// Will clear all children. If item source is null - return.
        /// </summary>
        private void FillLayout() {
            Children.Clear();

            if (ItemsSource == null) {
                return;
            }

            //
            // TODO: refactor layout filling and items creation
            //
            if (IsGrouped) {
                foreach (object group in ItemsSource) {
                    Children.Add(PrepareGroup(group));
                }
            }
            else {
                foreach (object item in ItemsSource) {
                    Children.Add(PrepareSingleItem(item));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private StackListItemBase PrepareSingleItem(object item) {
            try {
                StackListItemBase stackListItem = (StackListItemBase)ItemTemplate.CreateContent();

                stackListItem.SelectionAction = OnItemSelected;
                stackListItem.BindingContext = item;

                return stackListItem;
            }
            catch (Exception exc) {
                throw new InvalidOperationException(
                    string.Format("StackList.PrepareSingleItem - {0}. Excaption details - {1}",
                    _ERORR_LAYOUT_FILLING,
                    exc.Message));
            }
        }

        private View PrepareGroup(object group) {
            try {
                StackLayout groupSpot = new StackLayout() {
                    Spacing = 0,
                    BindingContext = group
                };

                groupSpot.Children.Add((View)GroupHeaderTemplate.CreateContent());

                foreach (var item in (IList)group) {
                    groupSpot.Children.Add(PrepareSingleItem(item));
                }

                return groupSpot;
            }
            catch (Exception exc) {
                throw new InvalidOperationException(
                   string.Format("StackList.PrepareGroup - {0}. Excaption details - {1}",
                   _ERORR_LAYOUT_FILLING,
                   exc.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnItemSelected(StackListItemBase stackListItem) {
            if (_selectedStackListItem != null) {
                _selectedStackListItem.Deselected();
            }

            _selectedStackListItem = stackListItem;
            _selectedStackListItem.Selected();

            SelectedItem = stackListItem.BindingContext;
        }
    }
}