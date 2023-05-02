using Assets.Scripts.Infrastructure.Services.ScreansService.Container;
using Assets.Scripts.Infrastructure.Services.ScreansService.Data;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.ScreansService.Implementation
{
    public class ScreanService : IScreanService
    {
        public bool HasAnyScreanOpened => _opendScreans.Count > 0;

        private readonly IScreanContainer _screanContainer;
        private List<ScreanConfiguration> _opendScreans = null;

        public ScreanService(IScreanContainer screanContainer)
        {
            _screanContainer = screanContainer;
        }

        public void OpenScrean(ScreanType type)
        {
            ScreanConfiguration config = _screanContainer.GetPopupConfig(type);
            if (config == null)
            {
                Debug.LogError("NO SUCH A PREFAB FOUND");
                return;
            }

            SpawnScrean(config);
        }

        private void SpawnScrean(ScreanConfiguration config)
        {
            GameObject screanObject = Resources.Load<GameObject>(config.PrefabName);

            config.Implementation = Object.Instantiate(screanObject);
            _opendScreans.Add(config);
        }

        public void CloseScrean(ScreanType type)
        {
            ScreanConfiguration config = _screanContainer.GetPopupConfig(type);
            if (_opendScreans.Contains(config))
            {
                Object.Destroy(config.Implementation);
                _opendScreans.Remove(config);
            }
        }

    }
}
