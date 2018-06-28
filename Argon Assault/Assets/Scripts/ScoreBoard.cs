using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // Variables
    int score;
    Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
        ScoreUpdate();
    }

    private void ScoreUpdate()
    {
        scoreText.text = score.ToString();
    }

    public void ScoreHit(int scoreIncrease)
    {
        score = score + scoreIncrease;
        ScoreUpdate();
    }

}
