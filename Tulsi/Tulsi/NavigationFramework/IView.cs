namespace Tulsi.NavigationFramework {
    public interface IView {
        void ApplyVisualChangesWhileNavigating();

        void Dispose();

        void ReSubscribe();
    }
}
