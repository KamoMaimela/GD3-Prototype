using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BellTrigger : MonoBehaviour
{
    public float seconds = 0f;

    public static Text dialogueText;

    public bool Inside;

    public GameObject Bell;

    public bool SecondPhase = false;


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

        if (seconds >= 8) 
        {
            Bell.SetActive(true); //Only make a call for food once the player has gone and interacted with their sibling
            SecondPhase = true;
        }     

    }
}
