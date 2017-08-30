using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Specialized;
using System.Collections;

namespace Tulsi.Controls.PrimitiveSegmentControl {
    public sealed class PrimitiveSegment : StackLayout {

        private ObservableCollection<PrimitiveSegmentItemBase> _items;
        private PrimitiveSegmentItemBase _selectedItem;

        /// <summary>
        ///     ctor().
        /// </summary>
        public PrimitiveSegment() {
            Segments = new ObservableCollection<PrimitiveSegmentItemBase>();
            //
            // TODO: unsubscribe from that event...
            //
            Segments.CollectionChanged += OnSegmentsCollectionChanged;
        }

        /// <summary>
        ///     Segment items.
        /// </summary>
        public ObservableCollection<PrimitiveSegmentItemBase> Segments {
            get => _items;
            private set => _items = value;
        }

        private void OnSegmentsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
            if (e.Action == NotifyCollectionChangedAction.Add) {
                BuildLayout(e.NewItems);
            }
        }

        private void BuildLayout(IList itemsToAdd) {
            foreach (PrimitiveSegmentItemBase segmentItem in itemsToAdd) {
                TapGestureRecognizer tapGesture = new TapGestureRecognizer();
                tapGesture.Tapped += (s, e) => OnTap(segmentItem);
                segmentItem.BaseViewForTap.GestureRecognizers.Add(tapGesture);

                Children.Add(segmentItem);

                if (_selectedItem == null) {
                    _selectedItem = segmentItem;
                    _selectedItem.Select();
                }
            }
        }

        private void OnTap(PrimitiveSegmentItemBase tappedSegmentsView) {
            if (_selectedItem != null) {
                _selectedItem.Deselect();
            }

            _selectedItem = tappedSegmentsView; 
            _selectedItem.Select();

            if (_selectedItem.ItemCommand != null) {
                _selectedItem.ItemCommand.Execute(null);
            }
        }
    }
}