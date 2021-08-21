using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupFood : MonoBehaviour
{

    public Transform theDestination;
    public bool SibEaten = false;

    public float seconds = 0;

    void OnMouseDown()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Rigidbody>().useGravity = false;
        this.transform.position = theDestination.position;
        this.transform.parent = GameObject.Find("GameObject").transform;
    }

    void OnMouseUp()
    {
        this.transform.parent = null;
        GetComponent<Rigidbody>().useGravity = true;
        GetComponent<BoxCollider>().enabled = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Sibling")
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            mesh.Clear();
            SibEaten = true;
        }
    }

    void Update()
    {
        if (SibEaten == true)
        {
            seconds += Time.deltaTime;

            if (seconds >= 3)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
