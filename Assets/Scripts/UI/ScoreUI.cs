using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        UpdateText();
        PlayerStats.OnScoreUpdate += UpdateText;
    }

    void UpdateText()
    {
        scoreText.text = "Score: " + PlayerStats.GetScore.ToString();
    }
}
