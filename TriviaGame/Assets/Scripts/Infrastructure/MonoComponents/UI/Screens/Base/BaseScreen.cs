﻿namespace Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base
{
    public class BaseScreen : UIView, IBaseScreen
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
