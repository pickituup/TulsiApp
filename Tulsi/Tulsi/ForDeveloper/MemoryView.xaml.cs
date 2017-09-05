using System;
using Tulsi.ForDeveloper.Service;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.ForDeveloper {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MemoryView : ContentView {

        private readonly IMemoryService _memory;

        /// <summary>
        /// ctor().
        /// </summary>
        public MemoryView() {
            InitializeComponent();

            _memory = DependencyService.Get<IMemoryService>();

            RefreshScreen();
        }

        protected void HandleClicked(object sender, EventArgs e) {
            RefreshScreen();
        }

        void RefreshScreen() {

            UsedMemory.Text = "";
            FreeMemory.Text = "";
            HeapMemory.Text = "";
            MaxMemory.Text = "";
            HeapUsage.Text = "";
            TotalUsage.Text = "";

            UsedMemory.TextColor = Color.Black;
            FreeMemory.TextColor = Color.Black;
            HeapMemory.TextColor = Color.Black;
            MaxMemory.TextColor = Color.Black;
            HeapUsage.TextColor = Color.Black;
            TotalUsage.TextColor = Color.Black;


            if (_memory != null) {
                MemoryInfo info = _memory.GetInfo();
                if (info != null) {
                    UsedMemory.Text = String.Format("{0:N}", info.UsedMemory);

                    FreeMemory.Text = String.Format("{0:N}", info.FreeMemory);

                    HeapMemory.Text = String.Format("{0:N}", info.TotalMemory);

                    MaxMemory.Text = String.Format("{0:N}", info.MaxMemory);
                    HeapUsage.Text = String.Format("{0:P}", info.HeapUsage());
                    TotalUsage.Text = String.Format("{0:P}", info.Usage());

                    if (info.Usage() > 0.8) {
                        FreeMemory.TextColor = Color.Red;
                        UsedMemory.TextColor = Color.Red;
                        TotalUsage.TextColor = Color.Red;
                    }
                }
            }
        }
    }
}