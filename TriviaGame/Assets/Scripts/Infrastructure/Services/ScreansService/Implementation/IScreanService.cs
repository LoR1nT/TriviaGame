using Assets.Scripts.Infrastructure.Services.ScreansService.Data;


namespace Assets.Scripts.Infrastructure.Services.ScreansService.Implementation
{
    public interface IScreanService
    {
        public bool HasAnyScreanOpened { get; }
        public void OpenScrean(ScreanType type);
        public void CloseScrean(ScreanType type);
    }
}
