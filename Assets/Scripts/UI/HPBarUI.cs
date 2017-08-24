using UnityEngine;
using UnityEngine.UI;

public class HPBarUI : MonoBehaviour
{
    public Slider hpBar;
    public Text hpText;

    void Start()
    {
        UpdateHP();
        PlayerTrain.OnHpChange += UpdateHP;
    }

    void UpdateHP()
    {
        hpBar.value = PlayerTrain.CurrentHP;
        hpText.text = PlayerTrain.CurrentHP.ToString() + "/300"; 
    }

}
