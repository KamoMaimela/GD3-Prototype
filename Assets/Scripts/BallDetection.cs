using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetection : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("GreenCylinder")) //If green ball has been put in the green cylinder, it needs to be removed from the scene
        {
            gameObject.SetActive(false);
            BallManager.balls -= 1;
        }

       else if (collision.gameObject.CompareTag("RedCylinder"))
        {
            GameObject.Find("Dialogue").GetComponent<Dialogue>().SubjectResponds = true;
        }

    }
}
