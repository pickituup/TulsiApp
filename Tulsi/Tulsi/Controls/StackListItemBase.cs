using System;
using Xamarin.Forms;

namespace Tulsi.Controls {
    public abstract class StackListItemBase : ContentView {

        /// <summary>
        /// Public ctor.
        /// </summary>
        public StackListItemBase() {
            ItemSelectCommand = new Command(() => {
                SelectionAction(this);
            });
        }

        /// <summary>
        /// Under the hood this command invokes the appropriate
        /// SelectionAction(…) of the relative StackList. To avoid the errors use StackListItems
        /// only inside the StackLists.
        /// </summary>
        public Command ItemSelectCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Action<StackListItemBase> SelectionAction { get; set; }

        /// <summary>
        /// TODO: Try to make selected/deselected noon public
        /// Abstract selection behavior. Each inherited item will define it's own behavior.
        /// </summary>
        public abstract void Selected();

        /// <summary>
        /// TODO: Try to make selected/deselected noon public
        /// Abstract deselection behavior. Each inherited item will define it's own behavior.
        /// </summary>
        public abstract void Deselected();
    }
}