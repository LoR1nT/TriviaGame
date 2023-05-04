using Assets.Scripts.Infrastructure.Services.WindowsService.Data;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.Services.WindowsService.Container
{
    public class WindowsContainer
    {
        private readonly Dictionary<WindowsType, WindowsConfiguration> _windowsContainer = null;

        public WindowsContainer()
        {
            _windowsContainer = new Dictionary<WindowsType, WindowsConfiguration>
            {
                [WindowsType.LevelSwitch] = new WindowsConfiguration("LevelSwitch Windows", "Windows/LevelSwithWindows/LevelSwith_Window"),
                [WindowsType.PlayLavel] = new WindowsConfiguration("PlayLavel Window", "Windows/PlayLevelWindows/PlayLevel_Window"),
            };
        }

        public WindowsConfiguration GetWindowsConfig(WindowsType type)
        {
            if (!_windowsContainer.ContainsKey(type))
            {
                return null;
            }
            else
            {
                return _windowsContainer[type];
            }
        }
    }
}
