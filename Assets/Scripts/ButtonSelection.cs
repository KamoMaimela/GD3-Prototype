using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelection : MonoBehaviour
{
    public GameObject A_Button;
    public GameObject B_Button;
    public GameObject C_Button;
    public GameObject D_Button;
    public GameObject E_Button;
    public GameObject F_Button;
    public GameObject G_Button;
    public GameObject H_Button;

    public GameObject dialogueText2;

    public void Abutton()
    {
        A_Button.SetActive(false);
        B_Button.SetActive(false);

        GameObject.Find("Dialogue").GetComponent<Dialogue>().Q2 = true;

        GameObject.Find("Dialogue").GetComponent<Dialogue>().A = true;

        C_Button.SetActive(true);
        D_Button.SetActive(true);
    }

    public void Bbutton()
    {
        B_Button.SetActive(false);
        A_Button.SetActive(false);

        GameObject.Find("Dialogue").GetComponent<Dialogue>().Q2 = true;

        GameObject.Find("Dialogue").GetComponent<Dialogue>().B = true;

        C_Button.SetActive(true);
        D_Button.SetActive(true);
    }

    public void Cbutton()
    {
        C_Button.SetActive(false);
        D_Button.SetActive(false);

        GameObject.Find("Dialogue").GetComponent<Dialogue>().Q3 = true;

        GameObject.Find("Dialogue").GetComponent<Dialogue>().C = true;

        F_Button.SetActive(true);
        E_Button.SetActive(true);
    }

    public void Dbutton()
    {
        D_Button.SetActive(false);
        C_Button.SetActive(false);

        GameObject.Find("Dialogue").GetComponent<Dialogue>().Q3 = true;

        GameObject.Find("Dialogue").GetComponent<Dialogue>().D = true;

        F_Button.SetActive(true);
        E_Button.SetActive(true);
    }

    public void Ebutton()
    {
        E_Button.SetActive(false);
        F_Button.SetActive(false);

        GameObject.Find("Dialogue").GetComponent<Dialogue>().Q4 = true;

        GameObject.Find("Dialogue").GetComponent<Dialogue>().E = true;

        G_Button.SetActive(true);
        H_Button.SetActive(true);
    }

    public void Fbutton()
    {
        F_Button.SetActive(false);
        E_Button.SetActive(false);

        GameObject.Find("Dialogue").GetComponent<Dialogue>().Q4 = true;

        GameObject.Find("Dialogue").GetComponent<Dialogue>().F = true;

        G_Button.SetActive(true);
        H_Button.SetActive(true);
    }

    public void Gbutton()
    {
        G_Button.SetActive(false);
        H_Button.SetActive(false);

        //dialogueText2.SetActive(false);

        GameObject.Find("Dialogue").GetComponent<Dialogue>().G = true;

        A_Button.SetActive(false);
        B_Button.SetActive(false);
    }

    public void Hbutton()
    {
        H_Button.SetActive(false);
        G_Button.SetActive(false);

        //dialogueText2.SetActive(false);

        GameObject.Find("Dialogue").GetComponent<Dialogue>().H = true;

        A_Button.SetActive(false);
        B_Button.SetActive(false);
    }
}
