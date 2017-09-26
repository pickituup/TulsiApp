using SQLite;

namespace Tulsi.Data.DataBase.Tables {
    [Table("PasscodeState")]
    public class PasscodeState {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public int Pin { get; set; }

        public bool HasPasscode { get; set; }
    }
}
