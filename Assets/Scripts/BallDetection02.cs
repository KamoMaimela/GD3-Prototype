using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDetection02 : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("RedCylinder"))
        {
            gameObject.SetActive(false);
        }

    }
}
