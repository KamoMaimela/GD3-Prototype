using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public AudioSource EatSound;

    public Text dialogueText;


    void OnMouseDown() //Clicking on the food item makes a chewing sound.
    {
        EatSound.Play();
    }

}
