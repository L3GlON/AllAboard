using UnityEngine;

public class TurretMachineGun : Turret
{
    public Transform[] muzzles;



    public override void Update()
    {
        if (!turretDisabled)
        {
            base.Update();
            if (currentTarget != null)
            {
                if (fireTimer <= 0)
                {
                    Shoot();
                }
            }
            fireTimer -= Time.deltaTime;
        }
    }

    void Shoot()
    {
        fireTimer = fireRate;
        foreach(Transform muzzle in muzzles)
        {
            GameObject newBulletGO = Instantiate(ammoType, muzzle.position, muzzle.rotation) as GameObject;
            newBulletGO.GetComponent<Projectile>().SetTarget(currentTarget);
        }

    }
}
