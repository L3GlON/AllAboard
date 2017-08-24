using UnityEngine;


public class Tile : MonoBehaviour
{
    public BuildManager buildManager;

    [SerializeField]
    GameObject turretOnTile;

    float yOffsetForTurret = 0.1f;

#if UNITY_EDITOR
    void OnMouseDown()
    {
        if(turretOnTile != null)
        {
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        if (turretToBuild != null)
        {
            PlaceTurret();
        }
    }
#endif

    public void PlaceTurret()
    {
        GameObject turret = buildManager.GetTurretToBuild();
        if (buildManager.EnoughMoney())
        {
            Vector3 buildPosition = transform.position + new Vector3(0, yOffsetForTurret, 0);
            GameObject newTurret = Instantiate(turret, buildPosition, Quaternion.identity) as GameObject;
            buildManager.PayForTurret();
            turretOnTile = newTurret;
            newTurret.transform.SetParent(transform);  
        }
    }
}
