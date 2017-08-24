using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject impactEffect;

    Transform target;
    [SerializeField]
    float speed;
    [SerializeField]
    int damage;
    [SerializeField]
    float splashRadius;

    Vector2 direction;

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject, 2f);
        }
        else
        {
            //Rotating towards target
            transform.right = target.position - transform.position;

            direction = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (direction.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }
        }
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);
       
    }

    void HitTarget()
    {
        Destroy(Instantiate(impactEffect, transform.position, Quaternion.identity), 3f);
        if (splashRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, splashRadius);
        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform _target)
    {
        _target.GetComponent<EnemyLivingEntity>().TakeDamage(damage);
    }


    public void SetTarget(Transform _target)
    {
        target = _target;
    }

}
