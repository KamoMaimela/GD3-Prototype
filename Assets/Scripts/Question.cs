using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question : MonoBehaviour
{

    public Text dialogueText;
    public bool Inside= false;

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
                "\n <color=red>Z</color>: Give child" +
                "\n <color=red>E</color>: Eat food";
        }

        if (Input.GetKeyDown("Z"))
        {
            
        }

        if (Input.GetKeyDown("E"))
        {
            
        }
    }
}
