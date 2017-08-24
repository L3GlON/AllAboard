using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    public LayerMask tileMask;
    bool gameIsOver;



    void Start()
    {
        PlayerTrain.OnZeroHP += GameOver;
    }

    void Update()
    {
#if UNITY_EDITOR
        if(gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            Restart();
        }
#endif

        if (gameIsOver && Input.touchCount > 0)
        {
            Restart();
        }

        if (Input.touchCount == 1)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Vector2 touchPoint = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                RaycastHit2D hitInfo = Physics2D.Raycast(touchPoint, Vector2.zero, 0, tileMask);
                if (hitInfo.collider != null)
                {
                    hitInfo.collider.gameObject.GetComponent<Tile>().PlaceTurret();
                }
            }
        }

    }

    void GameOver()
    {
        gameIsOver = true;
        gameOverScreen.SetActive(true);
        foreach (Bomb bomb in FindObjectsOfType<Bomb>())
        {
            Destroy(bomb.gameObject);
        }
    }


    void Restart()
    {
        gameIsOver = false;
        PlayerStats.ResetStats();
        PlayerTrain.ResetTrain();
        foreach(Turret turret in FindObjectsOfType<Turret>())
        {
            Destroy(turret.gameObject);
        }
        gameOverScreen.SetActive(false);
    }
}
