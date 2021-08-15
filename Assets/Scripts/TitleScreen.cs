using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public GameObject Credits;

    public void StartGame()
    {
        SceneManager.LoadScene("01");
    }

    public void CreditsOpen()
    {
        Credits.SetActive(true);
    }
    
    public void CreditsClose()
    {
        Credits.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
