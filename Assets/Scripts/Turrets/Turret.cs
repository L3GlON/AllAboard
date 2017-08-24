using UnityEngine;

public class Turret : MonoBehaviour
{
    [HideInInspector]
    public Transform currentTarget;

    public GameObject ammoType;
    [SerializeField]
    protected float fireRate;
    protected float fireTimer;

    public Transform muzzleToRotate;
    [SerializeField]
    float minZAxisRotation;
    [SerializeField]
    float maxZAxisRotation;
    [SerializeField]
    float turnSpeed = 10f;

    protected bool turretDisabled;

    public int price;

    public string enemyTag = "Enemy";

    void Start()
    {
        PlayerTrain.OnZeroHP += DisableTurret;
        InvokeRepeating("UpdateTarget", 0f, .5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistanceToEnemy = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistanceToEnemy)
            {
                nearestEnemy = enemy;
                shortestDistanceToEnemy = distanceToEnemy;
            }
        }
        if (nearestEnemy != null)
        {
            currentTarget = nearestEnemy.transform;
        }
        else
        {
            currentTarget = null;
        }
    }

    public virtual void Update()
    {
        fireTimer -= Time.deltaTime;
        if(currentTarget != null)
        {
            LockOnTarget();
        }
    }

    void LockOnTarget()
    {
        //Target lock on
        float distanceToTarget = Vector2.Distance(currentTarget.position, transform.position);
        float xDistanceToTarget = currentTarget.position.x - transform.position.x;
        float zAngle = Mathf.Acos(xDistanceToTarget / distanceToTarget) * Mathf.Rad2Deg;
        zAngle = Mathf.Clamp(zAngle, minZAxisRotation, maxZAxisRotation);

        Quaternion lookRotation = Quaternion.Euler(0, 0, zAngle);
        Vector3 rotationSmoothed = Quaternion.Lerp(muzzleToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        muzzleToRotate.rotation = Quaternion.Euler(0, 0, rotationSmoothed.z);
    }

    void DisableTurret()
    {
        turretDisabled = true;
    }

} 
