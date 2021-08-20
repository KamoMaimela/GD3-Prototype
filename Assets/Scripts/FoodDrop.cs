using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodDrop : MonoBehaviour
{

    public float seconds = 0f;

    public GameObject Food;

    public Text dialogueText;

    void Update()
    {
        //adding a timer so that the food only drops once the bell has stopped ringing 
        seconds += Time.deltaTime;
       
        if(seconds >= 5)
        {
            Drop();
        }
    }

    void Drop()
    {
        Food.SetActive(true);
        dialogueText.text = "Food Time";
    }
}
