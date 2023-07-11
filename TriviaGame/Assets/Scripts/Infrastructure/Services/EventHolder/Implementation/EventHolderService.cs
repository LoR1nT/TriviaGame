using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services.EventHolder.Implementation
{
    public class EventHolderService : IEventHolderService
    {
        public Action OnLevelStartEvent { get; set; }

        public void OnLevelStart()
        {
            var temp = OnLevelStartEvent;
            if(temp != null)
            {
                temp.Invoke();
            }
        }

        public Action<bool> OnSwitchLevelMenuViewEvent { get; set; }

        public void OnSwitchLevelMenuView(bool isMenuView)
        {
            var temp = OnSwitchLevelMenuViewEvent;
            if(temp != null)
            {
                temp.Invoke(isMenuView);
            }
        }

        public Action<int> OnLevelFinishEvent { get; set; }

        public void OnLevelFinish(int numderOfStarsReached)
        {
            var temp = OnLevelFinishEvent;
            if (temp != null)
            {
                temp.Invoke(numderOfStarsReached);
            }
        }
    }
}
