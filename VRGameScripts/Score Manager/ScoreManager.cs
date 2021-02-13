using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public static ScoreManager instance;
    [SerializeField]
    Text scoreText;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        scoreText.text = "Points: " + score.ToString();
    }
}
