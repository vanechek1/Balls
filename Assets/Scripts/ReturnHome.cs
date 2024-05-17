using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnHome : MonoBehaviour
{
    public AudioSource ad;
    public AudioClip clickBt;
    public void RHome()
    {
        ad.PlayOneShot(clickBt);
        int OneGameCoins = PlayerPrefs.GetInt("GameCoins");
        int coins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", coins + OneGameCoins);
        SceneManager.LoadScene("StartGame");
    }
}
