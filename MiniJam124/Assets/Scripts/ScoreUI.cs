using System;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _lapText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_Text _timerText;

    private void Start()
    {
        Game.Singleton.CurrentPlayer.GetComponent<PlayerInventory>().OnhandWarmerCollected.AddListener(UpdatescoreText);
        Game.Singleton.ProgressTracker.OnLap += OnLap;
    }

    private void Update()
    {
        var elapsed = Game.Singleton.TimeSinceStart;
        _timerText.text = $"Time: {elapsed.Minutes:D2}:{elapsed.Seconds:D2}:{(int)(elapsed.Milliseconds/10f):D2}";
    }

    private void OnLap(int lap)
    {
        _lapText.text = $"Lap {lap + 1}/{Game.Singleton.Settings.RequiredLaps}";
    }

    public void UpdatescoreText(PlayerInventory playerInventory)
    {
        scoreText.text = "x" + playerInventory.NumberOfhandWarmer;
    }
}
