using UnityEngine;

public class ShopUIController : MonoBehaviour
{
    public GameObject shopUI;

    public void OpenCloseShop()
    {
        if(shopUI.active)
        {
            shopUI.SetActive(false);
        }
        else
        {
            shopUI.SetActive(true);
        }
    }

    public void CloseShop()
    {
        shopUI.SetActive(false);
    }
}
