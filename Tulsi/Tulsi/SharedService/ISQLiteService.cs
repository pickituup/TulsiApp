namespace Tulsi.SharedService {
    public interface ISQLiteService {
        bool IsPasscodeExist();

        void SetPin(int pin);

        bool CheckPin(int pin);

        void ClearPasscode();
    }
}
