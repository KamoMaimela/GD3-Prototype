using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodDrop : MonoBehaviour
{

    public float seconds = 0f;

    public GameObject Food;

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
    }
}
