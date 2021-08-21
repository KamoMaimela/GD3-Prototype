using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Question : MonoBehaviour
{
    public AudioSource EatSound;

    public Text dialogueText;
    public bool Inside= false;

    public float seconds = 0f;

    public bool HasEaten = false;

    public GameObject Food;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Inside = true;  
        }  
    }

    void Update()
    {
        if (GameObject.Find("BellTrigger").GetComponent<BellTrigger>().SecondPhase == true && Inside) //Only ask the question once the player has gotten closer to the pellet.
        {
           dialogueText.text = "Will you give this to the child or eat it yourself?"+
                "\n Pick up and give to child" +
                "\n <color=red>E</color>: Eat food";
        }

        if (Input.GetKeyDown(KeyCode.E)) 
        {
            EatSound.Play();
            HasEaten = true;
        }
        
        if (HasEaten == true)
        {
            seconds += Time.deltaTime;
            Food.SetActive(false);
        }

        if (seconds >= 5) //Change scene
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
