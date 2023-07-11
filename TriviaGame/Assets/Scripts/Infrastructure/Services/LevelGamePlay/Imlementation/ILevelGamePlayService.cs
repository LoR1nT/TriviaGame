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
        public bool CheckStateIsInGame();
        public void TimeOut();
        public void OpenQuestion();
        public LevelData GetLevelData();
        public void QuitLevel();
        public int GetScoreCorrect();
        public int GetScoreInCorrect();
    }
}
