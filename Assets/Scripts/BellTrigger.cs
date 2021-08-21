using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BellTrigger : MonoBehaviour
{
    public float seconds = 0f;
    public float secondsUntilEnd = 0f;

    public Text dialogueText;

    public bool Inside;

    public GameObject Bell;

    public bool SecondPhase = false;

    private string scene5;

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
