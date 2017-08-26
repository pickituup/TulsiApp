using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Tulsi.Model.DataContainers.DataItems;
using Xamarin.Forms;

namespace Tulsi.Model.DataContainers {
    public class ArrivalsContainer {

        public List<ArrivalItem> BuildArrivalstems() {
            return new List<ArrivalItem>() {
                new ArrivalItem {
                    Title = "PSO Orch",
                    Value = 100.110m,
                    Number="280",
                    Icon =ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.greencircle.png");
                            return stream; })
                },
                new ArrivalItem {
                    Title = "PSO Orch",
                    Value = 100.110m,
                    Number="280",
                    Icon =ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                            return stream; })
                },
                new ArrivalItem {
                    Title = "PSO Orch",
                    Value =  100.110m,
                    Number="280",
                    Icon =ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                            return stream; })
                },
                new ArrivalItem {
                    Title = "PSO Orch",
                    Value =  100.110m,
                    Number="280",
                    Icon =ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.purplecircle.png");
                            return stream; })
                }
            };
        }
    }
}
