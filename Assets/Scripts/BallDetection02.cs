using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetection02 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedCylinder")) //If red ball has been put in the red cylinder, it needs to be removed from the scene
        {
            gameObject.SetActive(false);
            BallManager.balls -= 1;
        }

        else if (collision.gameObject.CompareTag("GreenCylinder"))
        {
            GameObject.Find("Dialogue").GetComponent<Dialogue>().SubjectResponds = true;
        }
    }
}
