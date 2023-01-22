using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Singleton;
    public Player CurrentPlayer;
    public ProgressTracker ProgressTracker;
    public DateTime StartTime;
    public TimeSpan TimeSinceStart => DateTime.Now - StartTime;
    public GameState GameState { get; private set; }
    [field: SerializeField] public GameSettings Settings { get; private set; }

    private void Awake()
    {
        if (!Singleton)
        {
            Singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartTime = DateTime.Now;
        GameState = GameState.Racing;
        ProgressTracker.OnLap += OnLap;
    }

    private void OnLap(int obj)
    {
        if (obj == Singleton.Settings.RequiredLaps)
        {
            GameState = GameState.CompletedRace;
        }
    }
}

public enum GameState
{
    Menus,
    AwaitingStart,
    Racing,
    Paused,
    CompletedRace,
}