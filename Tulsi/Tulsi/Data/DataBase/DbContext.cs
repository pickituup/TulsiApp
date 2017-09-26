using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Data.DataBase.Tables;

namespace Tulsi.Data.DataBase {
    public sealed class DbContext {

        private readonly string _dataBasePath;

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="dataBasePath"></param>
        public DbContext(string dataBasePath) {
            _dataBasePath = dataBasePath;
        }

        public bool IsPasscodeExist() {
            using (var db = new SQLiteConnection(_dataBasePath)) {
                try {
                    PasscodeState passcode = db.Get<PasscodeState>(x => x.HasPasscode);

                    if (passcode != null) {
                        return passcode.HasPasscode;
                    } else {
                        return false;
                    }
                } catch (Exception exc) {
                    return false;
                }
            }
        }

        public void ClearPasscode() {
            using (var db = new SQLiteConnection(_dataBasePath)) {
                try {
                    PasscodeState passcode = db.Get<PasscodeState>(x => x.HasPasscode);
                    db.DropTable<PasscodeState>();
                } catch (Exception exc) {
                    return;
                }
            }
        }

        public bool IsValidPin(int pin) {
            using (var db = new SQLiteConnection(_dataBasePath)) {
                try {
                    PasscodeState passcode = db.Get<PasscodeState>(x => x.HasPasscode);

                    if (pin.Equals(passcode.Pin))
                        return true;
                    else
                        return false;
                } catch (Exception exc) {
                    return false;
                }
            }
        }

        public void SetPin(int pin) {
            using (var db = new SQLiteConnection(_dataBasePath)) {
                db.DropTable<PasscodeState>();

                db.BeginTransaction();
                db.CreateTable<PasscodeState>();
                db.Insert(new PasscodeState { HasPasscode = true, Pin = pin });
                db.Commit();
            }
        }
    }
}
