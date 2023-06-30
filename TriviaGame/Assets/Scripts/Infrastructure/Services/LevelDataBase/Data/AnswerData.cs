using System;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.LevelDataBase.Data
{
    [Serializable]
    public class AnswerData
    {
        [SerializeField] private int _indexOfAnswer;
        [SerializeField] private string _textOfAnswer;
        [SerializeField] private bool _isCorectAnswer;

        public int Index { get { return _indexOfAnswer; } }
        public string Text { get { return _textOfAnswer; } }
        public bool IsCorect { get { return _isCorectAnswer; } }
    }
}
