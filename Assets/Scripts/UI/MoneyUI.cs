using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText;

    void Start()
    {
        UpdateText();
        PlayerStats.OnMoneyUpdate += UpdateText;
    }

    void UpdateText()
    {
        moneyText.text = "$: " + PlayerStats.GetMoneyCount.ToString();
    }
}
