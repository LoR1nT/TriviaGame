namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base
{
    public interface IBasePopup
    {
        void Initialize();
        void Open();
        void Hide();
        void Dispose();
        void Close();
    }
}