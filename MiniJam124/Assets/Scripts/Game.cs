using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Singleton;
    public Player CurrentPlayer;
    public ProgressTracker ProgressTracker;
    public DateTime StartTime;
    private DateTime _endTime;
    public TimeSpan TimeSinceStart => _endTime - StartTime;
    public GameState GameState { get; set; }
    [field: SerializeField] public GameSettings Settings { get; private set; }

    [SerializeField] private AudioSource _source;
    public Action<int> OnHighScore;

    private void Awake()
    {
        if (!Singleton)
        {
            Singleton = this;
        }
        else
        {
           Destroy(Singleton.gameObject);
           Singleton = this;
        }
    }

    public void StartRace()
    {
        StartTime = DateTime.Now;
        GameState = GameState.Racing;
        if (_source)
        {
            _source.Play();
        }
    }

    private void Start()
    {
        if(ProgressTracker)
            ProgressTracker.OnLap += OnLap;
    }

    private void Update()
    {
        if (GameState == GameState.Racing)
        {
            _endTime = DateTime.Now;
        }
    }

    private void OnLap(int obj)
    {
        if (obj == Singleton.Settings.RequiredLaps)
        {
            GameState = GameState.CompletedRace;
            
            var score = CurrentPlayer.GetComponent<PlayerInventory>().NumberOfhandWarmer;
            if (score > PlayerPrefs.GetInt("score", 0))
            {
                PlayerPrefs.SetInt("score", score);
                OnHighScore?.Invoke(score);
            }

            StartCoroutine(FadeToMenu());
        }
    }

    private IEnumerator FadeToMenu()
    {
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
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