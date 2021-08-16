using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallManager : MonoBehaviour
{
    public static int balls = 3;
    
    //In this script I am checking to see how many balls are still left in the scene. And if all have been placed in their respective holders, the player can move onto the next scene.
    void Update()
    {
        Debug.Log(balls);

        if(balls <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
