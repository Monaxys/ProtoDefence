using System;

namespace Defence.QuestSystem{
    ///<summary>
    /// Contains all event that hapens with player
    ///</summary>
    public class PlayerEvents
    {
        public event Action<int> onGoldReceived;
        public void GoldReceived(int goldAmount) {
            onGoldReceived?.Invoke(goldAmount);
        }
    }
}
