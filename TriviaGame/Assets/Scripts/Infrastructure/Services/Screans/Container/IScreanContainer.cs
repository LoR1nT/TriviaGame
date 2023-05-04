using Infrastructure.Services.Screans.Data;

namespace Infrastructure.Services.Screans.Container
{
    public interface IScreanContainer
    {
        public ScreanConfiguration GetScreanConfig(ScreanType type);
    }
}
