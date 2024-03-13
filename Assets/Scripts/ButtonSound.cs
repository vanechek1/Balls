using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public Image MusicButton;
    public Sprite onMusic;
    public Sprite offMusic;
    static public bool wasClicked = false;

    public void ButtonSoundClick()
    {
        if(wasClicked == false)
        {
            MusicButton.GetComponent<Image>().sprite = offMusic;
            wasClicked = true;
        }
        else
        {
            MusicButton.GetComponent<Image>().sprite = onMusic;
            wasClicked = false;
        }
    }
}
