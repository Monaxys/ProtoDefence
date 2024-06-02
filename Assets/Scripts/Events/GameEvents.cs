using System;

namespace  Defence.QuestSystem{
    ///<summary>
    /// Contains all major event that affective game
    ///</summary>
    public class GameEvents
    {
        public event Action<int> onLevelStart;
        public void LevelStart(int level) {
            onLevelStart?.Invoke(level);
        }
        public event Action onLevelEnd;
        public void LevelEnd() {
            onLevelEnd?.Invoke();
        }
    }
}
