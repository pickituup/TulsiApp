using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tulsi.Controls {
    public sealed class StackList : StackLayout {
        private static readonly string _ERORR_LAYOUT_FILLING = "Check validity of ItemsSource or ItemTemplate";

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create("ItemsSource",
                typeof(IList),
                typeof(StackList),
                propertyChanged: OnItemsSourceChanged);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create("ItemTemplate",
                typeof(DataTemplate),
                typeof(StackList),
                propertyChanged: OnItemTemplateChanged);

        /// <summary>
        /// 
        /// </summary>
        public IList ItemsSource {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        /// <summary>
        /// For correctly work try to use DataTemplate with ViewElement inside (some kind of 
        /// Layout with it's entrails)
        /// </summary>
        public DataTemplate ItemTemplate {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="oldVal"></param>
        /// <param name="newVal"></param>
        private static void OnItemTemplateChanged(BindableObject obj, object oldVal, object newVal) {
            StackList layout = obj as StackList;

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
            StackList layout = obj as StackList;

            if (layout != null && layout.ItemTemplate != null) {
                layout.FillLayout();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void FillLayout() {
            Children.Clear();

            foreach (var item in ItemsSource) {
                try {
                    View view = (View)ItemTemplate.CreateContent();

                    view.BindingContext = item;
                    Children.Add(view);
                }
                catch (Exception exc) {
                    throw new InvalidOperationException(
                        string.Format("StackList.BuildLayout - {0}. Excaption details - {1}",
                        _ERORR_LAYOUT_FILLING,
                        exc.Message));
                }
            }
        }
    }
}
