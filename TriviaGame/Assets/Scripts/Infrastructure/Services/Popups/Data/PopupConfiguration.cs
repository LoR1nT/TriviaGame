using Assets.Scripts.Infrastructure.MonoComponents.UI.Popups.Base;

namespace Infrastructure.Services.Popups.Data
{
    public class PopupConfiguration
    {
        public string PopupName { get; } = string.Empty;
        public string PrefabName { get; } = string.Empty;
        public BasePopup Implementation { get; set; }

        public PopupConfiguration(string name, string prefabName)
        {
            PopupName = name;
            PrefabName = prefabName;
        }
    }
}