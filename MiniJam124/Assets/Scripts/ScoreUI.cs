using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _lapText;
    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        Game.Singleton.CurrentPlayer.GetComponent<PlayerInventory>().OnhandWarmerCollected.AddListener(UpdatescoreText);
        Game.Singleton.ProgressTracker.OnLap += OnLap;
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
