using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    float Yrot;
    RaycastHit hit;
    GameObject grabbedOBJ;
    public Transform grabPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>())
        {
            grabbedOBJ = hit.transform.gameObject;
        }
        else if (Input.GetMouseButtonUp(1))
        {
            grabbedOBJ = null;
        }

        if (grabbedOBJ)
        {
            grabbedOBJ.GetComponent<Rigidbody>().velocity = 10 * (grabPos.position - grabbedOBJ.transform.position);
        }
    }
}
