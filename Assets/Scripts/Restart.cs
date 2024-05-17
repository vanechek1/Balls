using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
    public AudioSource ad;
    public AudioClip clickBt;
    public void RestartLevel()
    {
        ad.PlayOneShot(clickBt);
        Player.CheckedLose = "n";
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OpenShop()
    {
        ad.PlayOneShot(clickBt);
        SceneManager.LoadScene("Shop");
    }

    public void StartGame()
    {
        ad.PlayOneShot(clickBt);
        SceneManager.LoadScene("SampleScene");
    }

    public void StartCarsGame()
    { 
        ad.PlayOneShot(clickBt);
        SceneManager.LoadScene("CarsGame");
    }

    public void StartAnimalsGame()
    {
        ad.PlayOneShot(clickBt);
        SceneManager.LoadScene("AnimalsGame");
    }

}
