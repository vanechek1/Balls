using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class YanShop : MonoBehaviour
{
    public string objectName;
    public int sum;
    public TextMeshProUGUI score;
    public void OnButtonDown()
    {
        int coins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins",coins+sum);
        score.text = (coins+sum).ToString();
    }
}
