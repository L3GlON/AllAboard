using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject[] turrets;
    GameObject currentTurretToBuild;

    public GameObject GetTurretToBuild()
    {
        return currentTurretToBuild;
    }

    public bool EnoughMoney()
    {
        if(PlayerStats.GetMoneyCount > currentTurretToBuild.GetComponent<Turret>().price)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void PayForTurret()
    {
        PlayerStats.SpendMoney(currentTurretToBuild.GetComponent<Turret>().price);
    }

    public void ChooseMachineGunTurret()
    {
        currentTurretToBuild = turrets[0];
    }


    public void ChooseMissileLauncherTurret()
    {
        currentTurretToBuild = turrets[1];
    }
}
