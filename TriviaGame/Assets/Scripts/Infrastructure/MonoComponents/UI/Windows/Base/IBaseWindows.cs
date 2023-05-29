namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base
{
    public interface IBaseWindows
    {
        void Initialize();
        void Open();
        void Hide();
        void Dispose();
        void Close();
    }
}
