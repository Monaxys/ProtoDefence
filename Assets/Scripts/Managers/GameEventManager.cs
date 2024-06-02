using UnityEngine;
using Defence.QuestSystem;

///<summary>
/// Singleton for easy access to all events
///</summary>
[System.Serializable]
public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance;

    public PlayerEvents playerEvents;
    public GameEvents gameEvents;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Game Events Manager in the scene.");
            Destroy(instance);
        }
        instance = this;
    }

    private void InitializeEvents() {
        // initialize all events
        playerEvents = new PlayerEvents();
        gameEvents = new GameEvents();
    }

    public static GameEventsManager Get() {
        return instance;
    }
}
