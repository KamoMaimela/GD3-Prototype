using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dialogue : MonoBehaviour
{
    public Text dialogueText;
    public Text dialogueText2;

    public string[] sentences;
    private int index;
    private float TypingSpeed = 0.05f;
    public GameObject button;
    public GameObject button2;
    public bool SubjectResponds;
    public float timeLeftWarning = 30f;
    public float timeLeftEnd = 60f;
    public bool ScriptBlank = false;
    Scene scene;
    private string thisScene;

    public bool A;
    public bool B;
    public bool C;
    public bool D;
    public bool E;
    public bool F;
    public bool G;
    public bool H;

    public bool Q1;
    public bool Q2;
    public bool Q3;
    public bool Q4;

    public float playerScore = 30;

    private void Start()
    {
        StartCoroutine(SlowType());
        scene = SceneManager.GetActiveScene();
        thisScene = scene.name;
        Q1 = true;

       
    }

    private void Update()
    {
        if (dialogueText.text == sentences[index])
        {
            button.SetActive(true);
        }

        CheckPlayerResponse();
        EndDialogue();

        if (Input.GetKeyDown("space"))
        {
            SubjectResponds = true;
        }
    }

    private IEnumerator SlowType()
    {
        foreach (char letter in sentences[index].ToCharArray())
        {
            yield return new WaitForSeconds(TypingSpeed);
            dialogueText.text += letter;
        }
    }

    public void NextSection()
    {
        button.SetActive(false);

        if (index < sentences.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(SlowType());
        }
        else   //Dialogue has ended
        {
            dialogueText.text = "";
            button.SetActive(false);
        }
    }

    public void EndNextSection()
    {
        ScriptBlank = true;
        dialogueText2.text = "";
        button2.SetActive(false);

        if (scene.name == "04")
        {

        }
    }

    public void CheckPlayerResponse() //Call this response when player does not/does complete task.
    {

        if (scene.name == "01" && scene.name == "03")
        {
            if (SubjectResponds == true) //Need to check for this
            {
                ScriptBlank = false;
                dialogueText2.text = "Subject has responded and moved to the audio source. Continue with with necessary tests.";
                button2.SetActive(true);
            }
        }

        if (scene.name == "02")
        {
            if (SubjectResponds == true) //Need to check for this
            {
                ScriptBlank = false;
                dialogueText2.text = "Subject has only been able to partly execute the task.\nRevision may be needed to the original procedure performed due to potential errors\nas previously stipulated.";
                button2.SetActive(true);
            }
        }

        timeLeftWarning -= Time.deltaTime;
        if (timeLeftWarning < 0 && ScriptBlank == false)
        {
            ScriptBlank = false;
            dialogueText2.text = "Subject has not responded. Perhaps an error has been made.";

            button2.SetActive(true);
        }

        timeLeftEnd -= Time.deltaTime;
        if (timeLeftEnd < 0)
        {
            ScriptBlank = false;
            dialogueText2.text = "The task has not been executed. \nHenceforth, it is recommended that the subject be terminated.";

            button2.SetActive(true);
        }
    }

    public void EndDialogue()
    {
        if (scene.name == "04" && index >= 2)
        {
            if (Q1 == true)
            {
                dialogueText2.text = "A building has been bombed by war machines. " +
                        "\nYou have been given an official order to clear the rubble. " +
                        "\nDoing so might cause the collapse of the rest of the building and cause more people to die" +
                        "\nA. Clear the rubble. " +
                        "\nB. Do nothing.";
            }

            if (Q2 == true)
            {
                dialogueText2.text = "You are confronted with an enemy soldier who is about to shoot a child." +
                    "\nYou could kill the soldier, thereby killing the child. Or you could save the child and die." +
                    "\nC. Kill the soldier." +
                    "\nD. Save the child.";
            }


            if (Q3 == true)
            {
                dialogueText2.text = "There is a high ranking official who has had her eyes removed as a result of disease." +
                    "\nShe cannot serve the state without these, and has need of your own eyes. " +
                    "\nThis would render you blind." +
                    "\nE. Give them to her." +
                    "\nF. Refuse.";
            }
            if (Q4 == true)
            {
                dialogueText2.text = "There is a child that may one day slaughter hundreds of good people of the state. " +
                    "\nYou have the option to exterminate it. " +
                    "\nIt will not be painless." +
                    "\nG. Exterminate the child." +
                    "\nH. Leave the child";
            }


            CheckAnswers();
            button2.SetActive(true);

            if (SubjectResponds == true) //Need to check for this
            {
                ScriptBlank = false;
                dialogueText2.text = "Subject has only been able to partly execute the task.\nRevision may be needed to the original procedure performed due to potential errors\nas previously stipulated.";
                button2.SetActive(true);
            }
        }
    }

    void CheckAnswers()
    {
        if (A == true) //Clear the rubble
        {
            playerScore -= 5f; //Less rebellious
            A = false;
            Q1 = false;
            Q2 = true;
        }
        else if (B == true) //Do nothing
        {
            playerScore += 5f; //More rebellious
            B = false;
            Q1 = false;
            Q2 = true;
        }

        if (C == true) //Kill soldier
        {
            playerScore += 5f; //more rebellious/violent
            C = false;
            Q2 = false;
            Q3 = true;
        }
        else if (D == true) //Save child
        {
            playerScore -= 5f; //Less rebellious/violent
            D = false;
            Q2 = false;
            Q3 = true;
        }

        if (E == true) //Give them to her
        {
            playerScore -= 5f; //Less rebellious/violent
            E = false;
            Q3 = false;
            Q4 = true;
        }
        else if (F == true) //Refuse
        {
            playerScore += 5f; //more rebellious/violent
            F = false;
            Q3 = false;
            Q4 = true;
        }

        if (G == true) //Exterminate child
        {
            playerScore += 5f; //more rebellious/violent
            G = false;
            Q4 = false;
            End();
        }
        else if (H == true) //Leave child
        {
            playerScore -= 5f; //less rebellious/violent
            H = false;
            Q4 = false;
            End();
        }
    }

    void End()
    {
        //Look for value out of 60.
        //Max value == 60.
        //Lowest value == 0;
        //Divide into 4 sections. = 15.

        if (playerScore <= 15)
        {
            dialogueText2.text = "Congratulations, your will to serve has been noted. " +
                "\nWe recommend that you be put to use in the service industry, serving the good people of the state." +
                "\nIt is a great honour which you have been granted." +
                "\nIt is recommended that you do not make any... errors, or our kind decision will have to be revoked.";
        }

        if (playerScore > 15 && playerScore <= 30)
        {
            dialogueText2.text = "Your will to serve has been noted and congratulations are in order. " +
                "\nThe relevant industrial organisations who will be delivering applications for your transferral. " +
                "\nIf you are fortunate you shall be granted five happy years of service in one of our greatest factories." +
                "\nIt is recommended that the relevant surgical department be contacted immediately." +
                "\nLegs are not needed in factories.";
        }

        if (playerScore > 30 && playerScore <= 45)
        {
            dialogueText2.text = "Our tests have determined that it would be unwise for the subject to perform general service tasks" +
                "\non account of its aggressive mentality." +
                "\nTherefore, it is recommended that the war sector makes use of it in any way they deem reasonable." +
                "\nFurther biological adjustments can be made if they so wish. " +
                "\nYou are fortunate that you are not a complete failure.";
        }

        if (playerScore > 45 && playerScore <= 60)
        {
            dialogueText2.text = "It has been determined that the subject is unable to perform service tasks, " +
                "\non account of several unforseen emotional irregularities." +
                "\nPlease let department 2B know that they will have a new organ donar in the morning" +
                "\nand that they should perpare a new bed." +
                "\nLet this be a comfort to you subject. Service for the good of science and state is an honerable way to die.";
        }
    }
}
