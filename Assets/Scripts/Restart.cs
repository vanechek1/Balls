using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public AudioSource ad;
    public AudioClip clickBt;
    static public bool checkPress = false;
    public void RestartLevel()
    {
        ad.PlayOneShot(clickBt);
        Player.CheckedLose = "n";
        SceneManager.LoadScene("SampleScene");
    }
    public void OpenShop()
    {
        ad.PlayOneShot(clickBt);
        if (checkPress == false)
        {
            SceneManager.LoadScene("Shop");
            checkPress = true;
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
            checkPress = false;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void StartCarsGame()
    { 
        SceneManager.LoadScene("CarsGame");
    }

}
