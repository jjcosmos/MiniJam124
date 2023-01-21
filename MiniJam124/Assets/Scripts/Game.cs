using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Singleton;
    public Player CurrentPlayer;
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
        GameState = GameState.Racing;
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