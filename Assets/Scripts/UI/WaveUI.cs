using UnityEngine;
using UnityEngine.UI;

public class WaveUI : MonoBehaviour
{
    public Text waveText;

    public WaveManager waveManager;
    public EnemySpawner enemySpawner;

    [SerializeField]
    float fadeTime = 3f;
    float fadeTimer;

    void Start()
    {
        UpdateText();
        waveManager.OnWaveNumberChange += UpdateText;
        enemySpawner.OnWaveMessageTime += ShowText;
    }

    void Update()
    {
        fadeTimer -= Time.deltaTime;
        if(fadeTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void UpdateText()
    {
        waveText.text = "Wave " + waveManager.WaveNumber.ToString();
    }


    void ShowText()
    {
        gameObject.SetActive(true);
        fadeTimer = fadeTime;
    }


}
