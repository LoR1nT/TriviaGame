using Infrastructure.Services.Windows.Data;

namespace Infrastructure.Services.Windows.Container
{
    public interface IWindowsContainer
    {
        public WindowsConfiguration GetWindowsConfig(WindowsType type);
    }
}
