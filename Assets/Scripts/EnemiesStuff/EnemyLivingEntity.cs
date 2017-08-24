using UnityEngine;

public class EnemyLivingEntity: MonoBehaviour
{
    public GameObject deathEffect;

    [SerializeField]
    int startingHealth = 100;
    int currentHealth;

    [SerializeField]
    int moneyValue = 4;
    [SerializeField]
    int scoreValue = 10;

    void Awake()
    {
        currentHealth = startingHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth <=0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(Instantiate(deathEffect, transform.position, Quaternion.identity), 3f);
        PlayerStats.AddMoney(moneyValue);
        PlayerStats.AddScore(scoreValue);
        Destroy(gameObject);
    }

}
