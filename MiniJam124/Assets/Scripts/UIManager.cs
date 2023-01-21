using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    //Score Text
    [SerializeField]
    private TextMesh scoreText;

    //Score Number
    [SerializeField]
    private int score;

    void Start()
    {
        //Score set to 0 when started
        scoreText.text = "Score: " + 0;
    }

    public void AddScore(int addPoint)
    {
        score = +addPoint;
        //Update ScoreText
        scoreText.text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
