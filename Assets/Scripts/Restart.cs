using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    static public bool checkPress = false;
    public void RestartLevel()
    {
        Player.CheckedLose = "n";
        SceneManager.LoadScene("SampleScene");
    }
    public void OpenShop()
    {
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
}
