using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Eat : MonoBehaviour
{
    public AudioSource EatSound;

    public Text dialogueText;

    float distance;

    void OnMouseDown()
    {
        EatSound.Play();
        dialogueText.text = "";
    }

}
