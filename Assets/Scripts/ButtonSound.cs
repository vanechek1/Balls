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
    public AudioSource ad;
    public AudioClip clickBt;
    static public bool soundClick = false;
    public AudioSource fonMusic;

    public void ButtonSoundClick()
    {
        ad.PlayOneShot(clickBt);
        if (soundClick == false)
        {
            MusicButton.GetComponent<Image>().sprite = offMusic;
            fonMusic.enabled = false;
            soundClick = true;
        }
        else
        {
            MusicButton.GetComponent<Image>().sprite = onMusic;
            fonMusic.enabled = true;
            soundClick = false;
        }
    }
}
