using Assets.Scripts.Infrastructure.Services.LevelDataBase.Data;
using Infrastructure.Services.SevicesLocator;

namespace Assets.Scripts.Infrastructure.Services.LevelGamePlay.Imlementation
{
    public interface ILevelGamePlayService : IService
    {
        public void StartNewLevel(int levelIndex);
        public QuestionData GetCurentQuestion();
        public bool CheckAnswer(int answerIndex);
        public bool IsAnswerWasRigth();
        public bool CheckStateIsStart();
        public bool CheckStateIsInGame();
        public bool CheckTime(bool isTimeOut);
        public void OpenQuestion();
        public LevelData GetLevelData();
    }
}
