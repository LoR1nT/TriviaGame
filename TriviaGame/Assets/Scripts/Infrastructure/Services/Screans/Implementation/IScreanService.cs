using Assets.Scripts.Infrastructure.MonoComponents.UI.Screens.Base;
using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.SevicesLocator;

namespace Infrastructure.Services.Screans.Implementation
{
    public interface IScreanService : IService
    {
        public bool HasAnyScreanOpened { get; }
        public void OpenScrean<TScreen>(ScreanType type) where TScreen : BaseScreen;
        public void CloseScrean(ScreanType type);
    }
}
