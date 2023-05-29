namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base
{
    public interface IBaseScreen
    {
        void Initialize();
        void Open();
        void Hide();
        void Dispose();
        void Close();
    }
}
