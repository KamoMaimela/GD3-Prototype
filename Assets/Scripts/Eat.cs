using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Eat : MonoBehaviour
{
    public AudioSource EatSound;

    public Text dialogueText;

    public float seconds = 0f;

    public bool HasEaten = false;

    public GameObject Food;


    void OnMouseDown() //Clicking on the food item makes a chewing sound.
    {
        EatSound.Play();
        HasEaten = true;
    }

    void Update()
    {
        //adding a timer so that once the player has eaten, food item disappears

        if (HasEaten)
        {
            seconds += Time.deltaTime;
        }

        if (seconds >= 3)
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            mesh.Clear();
        }

        if (seconds >= 5) //Change scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
