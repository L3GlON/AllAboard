using UnityEngine;
using System.Collections;


[RequireComponent(typeof(WaveManager))]
public class EnemySpawner : MonoBehaviour
{
    public Transform spawnPoint;

    [SerializeField]
    float waveCooldown = 10f;
    float waveTimer = 5f;
    [SerializeField]
    float waveMessageTime = 3f;
    [SerializeField]
    float cooldownBetweenSpawns = 0.5f;

    GameObject enemyGO;
    int enemiesCount;

    WaveManager waveManager;
    bool waveProcessing;
    bool waveMessaged;
    bool noSpawn;

    public event System.Action OnWaveMessageTime;

    void Start()
    {
        PlayerTrain.OnZeroHP += BlockSpawning;
        PlayerTrain.OnReset += ResetSpawning;
        waveManager = GetComponent<WaveManager>();
    }

    void Update()
    {
        if (!noSpawn)
        {
            if (!waveProcessing && waveTimer <= 0)
            {
                waveProcessing = true;
                StartNextWave();
            }
            if (!waveMessaged && waveTimer <= waveMessageTime)
            {
                waveMessaged = true;
                OnWaveMessageTime();
            }


            waveTimer -= Time.deltaTime;
        }
    }


    void StartNextWave()
    {
        enemyGO = waveManager.GetEnemyGameObject();
        enemiesCount = waveManager.GetEnemyCount(); 

        StartCoroutine("SpawnEnemies");
    }
     
    IEnumerator SpawnEnemies()
    {
        for(int i = 0; i < enemiesCount; i++)
        {
            Instantiate(enemyGO, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(cooldownBetweenSpawns);
        }
        waveProcessing = false;
        waveMessaged = false;
        waveManager.IncreaseWaveNumber();
        waveTimer = waveCooldown;

    }

    public void BlockSpawning()
    {
        noSpawn = true;
    }

    public void ResetSpawning()
    {
        noSpawn = false;
        waveTimer = waveCooldown;
        waveManager.ResetWaves();
    }
}
