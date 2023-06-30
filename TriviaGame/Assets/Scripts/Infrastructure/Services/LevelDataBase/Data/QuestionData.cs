using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.LevelDataBase.Data
{
    [Serializable]
    public class QuestionData
    {
        [SerializeField] private int _index;
        [SerializeField] private string _text;
        [SerializeField] private List<AnswerData> _answers;

        public int Index { get { return _index; } }
        public string Text { get { return _text; } }
        public List<AnswerData> Answers { get { return _answers; } }
    }
}
