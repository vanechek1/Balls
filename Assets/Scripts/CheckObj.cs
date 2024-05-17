using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckObj : MonoBehaviour
{
    public TextMeshProUGUI score;
    public AudioSource ad;
    public AudioClip clickBt;
    private void Start()
    {
        int coins = PlayerPrefs.GetInt("coins");
        score.text = (coins).ToString();
    }
    public void ReturnHome()
    {
        ad.PlayOneShot(clickBt);
        int OneGameCoins = PlayerPrefs.GetInt("GameCoins");
        int coins = PlayerPrefs.GetInt("coins");
        PlayerPrefs.SetInt("coins", coins + OneGameCoins);
        SceneManager.LoadScene("StartGame");
    }

}
