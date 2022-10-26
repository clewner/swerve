using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonsounds : MonoBehaviour
{
    public static AudioClip hover;
    public static AudioClip click;
    static AudioSource audioSrc;

    public void HoverSound()
    {
        hover = Resources.Load<AudioClip>("hover");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.PlayOneShot(hover);
    }

    public void ClickSound()
    {
        click = Resources.Load<AudioClip>("click");
        audioSrc = GetComponent<AudioSource>();
        audioSrc.PlayOneShot(click);
    }

}
