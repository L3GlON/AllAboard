using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bomb;
    public Transform bombPoint;

    [SerializeField]
    float bombDropCooldownMin = 1;
    [SerializeField]
    float bombDropCooldownMax = 4;

    float bombDropCooldown;

    bool bombOnBoard = true;
    bool attackAlowed = true;

    void Start()
    {
        PlayerTrain.OnZeroHP += DisableAttack;
        bombDropCooldown = Random.Range(bombDropCooldownMin, bombDropCooldownMax);
    }


    void Update()
    {
        bombDropCooldown -= Time.deltaTime;


        if(bombDropCooldown <= 0 && bombOnBoard && attackAlowed)
        {
            DropBomb();
        }
    }


    void DropBomb()
    {
        bombOnBoard = false;
        Instantiate(bomb, bombPoint.position, Quaternion.identity);
    }

    void DisableAttack()
    {
        attackAlowed = false;
    }
}
