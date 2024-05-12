using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSound : MonoBehaviour
{
    public AudioSource menuSound;

    void Start()
    {
        Button[] buttons = FindObjectsOfType<Button>(true); 
        foreach (Button b in buttons)
        {
            b.onClick.AddListener(ButtonSound);
        }
    }
    public void ButtonSound()
    {
        menuSound.Play();
    }
}
