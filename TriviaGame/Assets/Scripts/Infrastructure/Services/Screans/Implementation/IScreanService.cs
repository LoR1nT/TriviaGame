using Infrastructure.Services.Screans.Data;
using Infrastructure.Services.SevicesLocator;

namespace Infrastructure.Services.Screans.Implementation
{
    public interface IScreanService : IService
    {
        public bool HasAnyScreanOpened { get; }
        public void OpenScrean(ScreanType type);
        public void CloseScrean(ScreanType type);
    }
}
