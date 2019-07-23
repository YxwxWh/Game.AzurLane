using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ButtonSound
{
    public static void ButtonClickPlay()
    {
        GameObject.Find("UI").GetComponent<AudioSource>().Play();
    }
}
