using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public AudioSource EatSound;

    float distance;

    void OnMouseDown()
    {
        EatSound.Play();
    }

}
