using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public AudioSource clickSound, audioSource;
    public Image muteIcon, unmuteIcon;

    public void OnClick()
    {
        clickSound.Play();
    }
    public void MuteSound()
    {
        audioSource.mute = !audioSource.mute;
        if(audioSource.mute)
        {
            muteIcon.transform.gameObject.SetActive(true);
            unmuteIcon.transform.gameObject.SetActive(false);
        }
        else
        {
            unmuteIcon.transform.gameObject.SetActive(true);
            muteIcon.transform.gameObject.SetActive(false);
        }
    }
}