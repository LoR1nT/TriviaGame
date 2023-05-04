using Assets.Scripts.Infrastructure.Services.ScreansService.Data;
using Infrastructure.Services.PopupService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.ScreansService.Container
{
    public interface IScreanContainer
    {
        public ScreanConfiguration GetScreanConfig(ScreanType type);
    }
}
