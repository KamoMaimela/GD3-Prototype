using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    //Here I check if player has responded by walking to the audio source. If so, subject responds bool has to be true
    void OnTriggerEnter (Collider other)
    {
       if (other.CompareTag("Player"))
        {
            Debug.Log("SoundDetected");

            GameObject.Find("Dialogue").GetComponent<Dialogue>().SubjectResponds = true;
        }
    }
}
