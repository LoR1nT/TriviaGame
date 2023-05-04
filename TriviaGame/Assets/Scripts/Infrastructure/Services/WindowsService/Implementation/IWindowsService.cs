using Assets.Scripts.Infrastructure.Services.WindowsService.Data;

namespace Assets.Scripts.Infrastructure.Services.WindowsService.Implementation
{
    public interface IWindowsService
    {
        public bool HasAnyScreanOpened { get; }
        public void OpenWindow(WindowsType type);
        public void CloseWindow(WindowsType type);
    }
}
