﻿using Assets.Scripts.Infrastructure.Services.ScreansService.Data;
using System.Collections.Generic;

namespace Assets.Scripts.Infrastructure.Services.ScreansService.Container
{
    public class ScreanContainer : IScreanContainer
    {
        private readonly Dictionary<ScreanType, ScreanConfiguration> _screanContainer = null;

        public ScreanContainer()
        {
            _screanContainer = new Dictionary<ScreanType, ScreanConfiguration>
            {
                [ScreanType.MainMenuScrean] = new ScreanConfiguration("MainMenu Screan", "Screnes/MainMenuScrean/MainMenu_screan"),
                [ScreanType.LoadingScrean] = new ScreanConfiguration("Loading Screan", "Screnes/LoadingScrean/Loading_screan"),
                [ScreanType.LevelsScrean] = new ScreanConfiguration("Level Screan", "Screnes/LevelsScrean/Levels_screan"),
            };
        }

        public ScreanConfiguration GetScreanConfig(ScreanType type)
        {
            if (!_screanContainer.ContainsKey(type))
            {
                return null;
            }
            else
            {
                return _screanContainer[type];
            }
        }
    }
}
