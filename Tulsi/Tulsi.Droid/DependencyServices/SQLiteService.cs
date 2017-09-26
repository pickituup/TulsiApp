using System.IO;
using Tulsi.Data.DataBase;
using Tulsi.Droid.DependencyServices;
using Tulsi.SharedService;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteService))]
namespace Tulsi.Droid.DependencyServices {
    public sealed class SQLiteService : ISQLiteService {

        private readonly DbContext _dbContext;

        /// <summary>
        ///     ctor().
        /// </summary>
        public SQLiteService() {
            _dbContext = new DbContext(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Tulsi.db"));
        }

        public bool CheckPin(int pin) {
            return _dbContext.IsValidPin(pin);
        }

        public void ClearPasscode() {
            _dbContext.ClearPasscode();
        }

        public bool IsPasscodeExist() {
            return _dbContext.IsPasscodeExist();
        }

        public void SetPin(int pin) {
            _dbContext.SetPin(pin);
        }
    }
}