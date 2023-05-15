namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base
{
    public abstract class BasePopup : UIView, IBasePopup
    {
        public virtual void Initialize()
        {
        }

        public virtual void Open()
        {
            gameObject.SetActive(true);
        }

        public virtual void Hide()
        {
            gameObject.SetActive(false);
        }

        public virtual void Dispose()
        {
        }

        public virtual void Close()
        {
            Destroy(gameObject);
        }
    }
}