using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject impactEffect;

    [SerializeField]
    int damage = 15;
    [SerializeField]
    float fallSpeed = 5f;

    void Update()
    {
        Fall();
    }


    void Fall()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Train"))
        {
            Destroy(Instantiate(impactEffect, transform.position, Quaternion.identity), 3f);
            Destroy(gameObject);
            PlayerTrain.DamageTrain(damage);
        }

    }
}
