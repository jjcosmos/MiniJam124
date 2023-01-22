using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _lapText;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private Image _fillImage;
    [SerializeField] private TMP_Text _highScoreText;

    private void Start()
    {
        Game.Singleton.CurrentPlayer.GetComponent<PlayerInventory>().OnhandWarmerCollected.AddListener(UpdatescoreText);
        Game.Singleton.ProgressTracker.OnLap += OnLap;
        Game.Singleton.OnHighScore += OnHighScore;
        OnLap(0);
    }

    private void OnHighScore(int obj)
    {
        _highScoreText.text = $"New High Score ({scoreText.text})!";
    }

    private void Update()
    {
        var elapsed = Game.Singleton.TimeSinceStart;
        _timerText.text = $"Time: {elapsed.Minutes:D2}:{elapsed.Seconds:D2}:{(int)(elapsed.Milliseconds/10f):D2}";
    }

    private void OnLap(int lap)
    {
        _lapText.text = lap >= Game.Singleton.Settings.RequiredLaps ? "Finish!" : $"Lap {lap + 1}/{Game.Singleton.Settings.RequiredLaps}";
    }

    public void UpdatescoreText(PlayerInventory playerInventory)
    {
        var fillAmount = Mathf.Clamp01((float)playerInventory.NumberOfhandWarmer / (float)Game.Singleton.Settings.MaxWarmersForMult);
        _fillImage.fillAmount = fillAmount;
        scoreText.text = "x" + playerInventory.NumberOfhandWarmer;
    }
}
