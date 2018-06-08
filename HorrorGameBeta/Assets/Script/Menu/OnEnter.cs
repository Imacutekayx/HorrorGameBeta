using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnter : MonoBehaviour {
    public GameObject menu;
    public AudioClip onMenu;
    public AudioClip click;
    private AudioSource audioSource;

    private bool inside = false;

    private void Start()
    {
        menu = GameObject.FindWithTag("Menu");
        audioSource = menu.GetComponent<AudioSource>();
    }

    private void OnMouseEnter()
    {
        audioSource.clip = onMenu;
        audioSource.Play();
        inside = true;
    }

    private void OnMouseExit()
    {
        inside = false;
    }

    private void Update()
    {
        if (inside)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.clip = click;
                audioSource.Play();
            }
        }
    }
}
