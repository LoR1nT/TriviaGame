using Assets.Scripts.Infrastructure.MonoComponents.UI.Windows.Base;
using Infrastructure.Services.SevicesLocator;
using Infrastructure.Services.Windows.Data;

namespace Infrastructure.Services.Windows.Implementation
{
    public interface IWindowsService : IService
    {
        public bool HasAnyScreanOpened { get; }
        public void OpenWindow<TWindow>(WindowsType type) where TWindow : BaseWindows;
        public void CloseWindow<TWindow>(WindowsType type) where TWindow : BaseWindows;
    }
}
