using UnityEngine;

public class RepairManager : MonoBehaviour
{
    [SerializeField]
    int baseRepairPoints = 40;
    [SerializeField]
    int repairPrice = 25;


    public void Repair()
    {
        if (PlayerTrain.CurrentHP < PlayerTrain.BaseHP)
        {
            PlayerStats.SpendMoney(repairPrice);
            PlayerTrain.RepairTrain(baseRepairPoints);
        }
    }
}
