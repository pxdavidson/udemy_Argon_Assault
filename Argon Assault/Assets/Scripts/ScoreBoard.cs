using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBoard : MonoBehaviour
{
    // Variables
    [SerializeField] int scorePerHit = 100;

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

    public void ScoreHit()
    {
        score = score + scorePerHit;
        ScoreUpdate();
    }

}
