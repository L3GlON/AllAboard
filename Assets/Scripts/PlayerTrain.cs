using UnityEngine;

public static class PlayerTrain
{
    static int baseTrainHP = 300;
    static int currentTrainHP = baseTrainHP;

    public static event System.Action OnHpChange;
    public static event System.Action OnZeroHP;
    public static event System.Action OnReset;

    public static void DamageTrain(int damage)
    {
        currentTrainHP -= damage;
        OnHpChange();
        if(currentTrainHP <= 0)
        {
            OnZeroHP();
        }
    }

    public static void RepairTrain(int repairPoints)
    {
        currentTrainHP += repairPoints;
        if(currentTrainHP > baseTrainHP)
        {
            currentTrainHP = baseTrainHP;
        }
        OnHpChange();
    }

    public static int CurrentHP
    {
        get
        {
            return currentTrainHP;
        }
    }

    public static int BaseHP
    {
        get
        {
            return baseTrainHP;
        }
    }

    public static void ResetTrain()
    {
        currentTrainHP = baseTrainHP;
        OnHpChange();
        OnReset();
    }
}
