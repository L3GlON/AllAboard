using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    public Text gameOverScoreText;

    void OnEnable()
    {
        gameOverScoreText.text = "Your score: " + PlayerStats.GetScore.ToString();
    }
}
