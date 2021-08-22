using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BellTrigger : MonoBehaviour
{
    public float seconds = 0f;
    public float secondsScene3 = 0f;
    public float secondsUntilEnd = 0f;

    public Text dialogueText;
    public Text dialogueText2;

    public bool Inside;

    public GameObject Bell;

    public bool SecondPhase = false;

    private string scene5;
    public AudioSource EatSound;
    public bool HasEaten = false;
    public GameObject Food;
    void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Within perimeter");
            Inside = true;
        }
    }

    void Update()
    {
        if (GameObject.Find("Dialogue").GetComponent<Dialogue>().FoodTimer == true && Inside) 
        {
           seconds += Time.deltaTime;
        }
        
        if (seconds >= 7) 
        {
            Bell.SetActive(true); //Only make a call for food once the player has gone and interacted with their sibling
            SecondPhase = true;
            dialogueText.text = "Food time.";
        }
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "03")
        {
            secondsScene3 += Time.deltaTime;
        }

        if (secondsScene3 >= 3 && Inside)
        {


            Bell.SetActive(true); //Only make a call for food once the player has gone and interacted with their sibling
            //SecondPhase = true;
            dialogueText.text = "Food time.";

            dialogueText2.text = "<color=red>E</color>: Eat food";

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
            //    GameObject.Find("Dialogue").GetComponent<Dialogue>().FoodTimer = true;
            //    Bell.SetActive(true); //Only make a call for food once the player has gone and interacted with their sibling
            //    SecondPhase = true;
            //    dialogueText.text = "Food time.";
        }

            if (scene.name == scene5)
        {
            secondsUntilEnd += Time.deltaTime;
        }

        if (secondsUntilEnd == 15)
        {
            SceneManager.LoadScene("Start");
        }
    }
}
