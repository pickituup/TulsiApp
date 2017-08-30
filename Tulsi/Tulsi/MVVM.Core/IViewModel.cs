namespace Tulsi.MVVM.Core {
    public interface IViewModel {
        void Dispose();

        void ReSubscribe();
    }
}
