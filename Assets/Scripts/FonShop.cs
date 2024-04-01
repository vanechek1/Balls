using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FonShop : MonoBehaviour
{
    public string objectName;
    public int price, access;
    public GameObject block;
    public TextMeshProUGUI objectPrice;
    void Awake()
    {
        AccessUpdate();
    }
    void AccessUpdate()
    {
        access = PlayerPrefs.GetInt(objectName + "Access");
        objectPrice.text = price.ToString();

        if (access == 1)
        {
            block.SetActive(false);
            objectPrice.gameObject.SetActive(false);
        }
    }

    public void OnButtonDown()
    {
        int coins = PlayerPrefs.GetInt("coins");

        if(access == 0)
        {
            if(coins >= price)
            {
                PlayerPrefs.SetInt(objectName + "Access", 1);
                PlayerPrefs.SetInt("coins", coins - price);
                AccessUpdate();
            }
        }
    }
}
