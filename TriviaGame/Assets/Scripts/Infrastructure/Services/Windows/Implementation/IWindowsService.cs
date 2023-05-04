using Infrastructure.Services.Windows.Data;

namespace Infrastructure.Services.Windows.Implementation
{
    public interface IWindowsService
    {
        public bool HasAnyScreanOpened { get; }
        public void OpenWindow(WindowsType type);
        public void CloseWindow(WindowsType type);
    }
}
