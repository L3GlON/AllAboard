using UnityEngine;

public class TurretMissileLauncher : Turret
{
    public Transform muzzle;


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

        GameObject newMissileGO = Instantiate(ammoType, muzzle.position, muzzle.rotation) as GameObject;
        newMissileGO.GetComponent<Projectile>().SetTarget(currentTarget);

    }
}
