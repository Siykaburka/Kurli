using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clickbutton : MonoBehaviour {

    AudioSource clicksours;
    public AudioClip clickCl;

    private void Start()
    {
        clicksours = gameObject.GetComponent<AudioSource>();
        clicksours.loop = false;
        clicksours.playOnAwake = false;
    }

    public void ClipPlay()
    {
        clicksours.clip = clickCl;
        clicksours.Play();
    }
}
