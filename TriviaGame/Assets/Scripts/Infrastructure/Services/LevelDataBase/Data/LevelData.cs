using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.LevelDataBase.Data
{
    [Serializable]
    public class LevelData
    {
        [SerializeField] private int _index;
        [SerializeField] private float _timeForAnswer;
        [SerializeField] private List<QuestionData> _questions;

        public int Index { get { return _index; } }
        public float TimeForAnswer { get { return _timeForAnswer; } }
        public List<QuestionData> Questions { get { return _questions; } }
    }
}
