using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public bool SiblingDetect = false;
    public float seconds = 0f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Sibling")
        {
            SiblingDetect = true;
        }
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "05" && SiblingDetect == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("Start");
            }

            seconds += Time.deltaTime;
            if (seconds >= 10)
            {
                SceneManager.LoadScene("Start");
            }
        }
    }
}
