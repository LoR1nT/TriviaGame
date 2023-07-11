using Infrastructure.Services.SevicesLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.EventHolder.Implementation
{
    public interface IEventHolderService : IService
    {
        public Action OnLevelStartEvent { get; set; }
        public void OnLevelStart();
        public Action<bool> OnSwitchLevelMenuViewEvent { get; set; }
        public void OnSwitchLevelMenuView(bool isMenuView);
        public Action<int> OnLevelFinishEvent { get; set; }
        public void OnLevelFinish(int numderOfStarsReached);
    }
}
