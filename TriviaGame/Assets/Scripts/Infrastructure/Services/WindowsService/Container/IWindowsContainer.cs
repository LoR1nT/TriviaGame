using Assets.Scripts.Infrastructure.Services.ScreansService.Data;
using Assets.Scripts.Infrastructure.Services.WindowsService.Data;

namespace Assets.Scripts.Infrastructure.Services.WindowsService.Container
{
    public interface IWindowsContainer
    {
        public WindowsConfiguration GetWindowsConfig(WindowsType type);
    }
}
