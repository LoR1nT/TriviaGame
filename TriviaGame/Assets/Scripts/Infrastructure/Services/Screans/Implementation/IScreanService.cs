using Infrastructure.Services.Screans.Data;

namespace Infrastructure.Services.Screans.Implementation
{
    public interface IScreanService
    {
        public bool HasAnyScreanOpened { get; }
        public void OpenScrean(ScreanType type);
        public void CloseScrean(ScreanType type);
    }
}
