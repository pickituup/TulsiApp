using Tulsi.Droid.DeveloperService;
using Tulsi.ForDeveloper;
using Xamarin.Forms;

[assembly: Dependency(typeof(AndroidMemoryService))]
namespace Tulsi.Droid.DeveloperService {
    public class AndroidMemoryService {

        /// <summary>
        ///     ctor().
        /// </summary>
        public AndroidMemoryService() {
        }


        public MemoryInfo GetInfo() {
            return MemoryHelper.GetMemoryInfo(Forms.Context);
        }
    }
}