using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdatescoreText(PlayerInventory playerInventory)
    {
        scoreText.text = playerInventory.NumberOfhandWarmer.ToString();
    }
}
