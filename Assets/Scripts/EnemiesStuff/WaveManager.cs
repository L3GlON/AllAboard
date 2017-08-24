using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyRed;
    [SerializeField]
    GameObject enemyGreen;
    [SerializeField]
    GameObject enemyBlue;

    int waveNumber = 1;

    public event System.Action OnWaveNumberChange;

    public int GetEnemyCount() 
    {
        return waveNumber + 2;
    }

    public void IncreaseWaveNumber()
    {
        waveNumber++;
        OnWaveNumberChange();
    }

    public GameObject GetEnemyGameObject()
    {
        if (waveNumber <= 10)
            return enemyRed;
        else if(waveNumber <= 20)
        {
            return enemyGreen;
        }
        else
        {
            return enemyBlue;
        }
    }

    public int WaveNumber
    {
        get
        {
            return waveNumber;
        }
    }

    public void ResetWaves()
    {
        waveNumber = 1;
        OnWaveNumberChange();
    }

}
