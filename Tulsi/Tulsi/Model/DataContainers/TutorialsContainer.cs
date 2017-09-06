using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Model.DataContainers.DataItems;
using Xamarin.Forms;

namespace Tulsi.Model.DataContainers {
    public sealed class TutorialsContainer {

        /// <summary>
        ///     Build tutorials content.
        /// </summary>
        /// <returns></returns>
        public List<TutorialItem> BuildProfitMenuItems() {
            return new List<TutorialItem>() {
                new TutorialItem {
                    Id = 1,
                    Title = "Tulsi",
                    SubTitle= string.Empty,
                    Icon = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.tulsi logo.png");
                            return stream; }),
                    Description="Have a god's eye on your business."
                },
                new TutorialItem {
                    Id = 2,
                    Title = string.Empty,
                    SubTitle= "Keep a Check",
                    Icon = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.slide1.gif");
                            return stream; }),
                    Description="Get notified for suspicious entries."
                },
                new TutorialItem {
                    Id = 3,
                    Title = string.Empty,
                    SubTitle= "Take Better Decisions",
                    Icon = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.slide2.gif");
                            return stream; }),
                    Description="Be better at your business with anytime reports."
                },
                new TutorialItem {
                    Id = 4,
                    Title = string.Empty,
                    SubTitle= "Coordinate together",
                    Icon = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.slide3.png");
                            return stream; }),
                    Description="Work with your whole team over quick chat."
                },
                new TutorialItem {
                    Id = 5,
                    Title = string.Empty,
                    SubTitle= "Wherever you are",
                    Icon = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.slide4.gif");
                            return stream; }),
                    Description= "Keep an eye on your business, even at the beach."
                }
            };
        }
    }
}
