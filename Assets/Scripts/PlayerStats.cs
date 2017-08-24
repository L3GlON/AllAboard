using UnityEngine;

public static class PlayerStats
{
    static int startingMoney = 1050;
    static int currentMoney = startingMoney;

    static int startingScore = 0;
    static int currentScore = startingScore;

    public static event System.Action OnScoreUpdate;
    public static event System.Action OnMoneyUpdate;

    public static void AddMoney(int amount)
    {
        currentMoney += amount;
        OnMoneyUpdate();
    }

    public static void SpendMoney(int amount)
    {
        currentMoney -= amount;
        OnMoneyUpdate();
    }

    public static void AddScore(int points)
    {
        currentScore += points;
        OnScoreUpdate();
    }

    public static int GetMoneyCount
    {
        get
        {
            return currentMoney;
        }
    }

    public static int GetScore
    {
        get
        {
            return currentScore;
        }
    }

    public static void ResetStats()
    {
        currentMoney = startingMoney;
        currentScore = startingScore;
        OnMoneyUpdate();
        OnScoreUpdate();
    }

}
