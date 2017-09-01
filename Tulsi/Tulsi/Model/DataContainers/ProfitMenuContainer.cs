using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Tulsi.Model.DataContainers.DataItems;
using Xamarin.Forms;

namespace Tulsi.Model.DataContainers {
    public class ProfitMenuContainer {

        /// <summary>
        ///     Build bottom profit menu.
        /// </summary>
        /// <returns></returns>
        public List<ProfitMenuItem> BuildProfitMenuItems() {
            return new List<ProfitMenuItem>() {
                new ProfitMenuItem {
                    Value = 0.0m,
                    Status="Income",
                    Image =ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.green_plus_icon.png");
                            return stream; })
                },
                new ProfitMenuItem {
                    Value = 163.89m,
                    Status="Expense",
                    Image =ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.red_minus_icon.png");
                            return stream; })
                }
                //new ProfitMenuItem {
                //    Value =  -163.89m,
                //    Status="loss",
                //    Image =ImageSource.FromStream(()=> {
                //            Assembly assembly = GetType().GetTypeInfo().Assembly;
                //            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.grayprofiticon.png");
                //            return stream; })
                //}
            };
        }
    }
}
