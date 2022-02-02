using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleManager : MonoBehaviour
{
    public TMP_InputField consoleInput;
    public Console consoleScript;

    private ConsoleFunctions functions;
    private DisableUI disableUIScript;
    private int amount = 0;
    private int amount2 = 0;
    private int amount3 = 0;

    private void Start()
    {
        functions = GetComponent<ConsoleFunctions>();
        disableUIScript = GetComponent<DisableUI>();
        Debug.Log("Kirjoita (help) nähdäksesi komennot");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Command(consoleInput.text);
            consoleInput.text = "";
            consoleInput.Select();
            consoleInput.ActivateInputField();
        }
    }

    void Command(string cmd)
    {
        if(cmd == "")
        {
            amount++;

            if(amount >= 25)
            {
                if(amount <= 25)
                {
                    Debug.Log("lopeta, ei ole hauskaa");
                }
                
                amount2++;
            }
            if(amount2 >= 25)
            {
                if (amount2 <= 25)
                {
                    Debug.Log("jos jatkat, niin suljen pelin");
                }
                amount3++;
            }
            if(amount3 >= 25)
            {
                PlayerPrefs.SetInt("ConsoleEnabled", 0);

                #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;

                #else
		        Application.Quit();

                #endif
            }
        }


        else if (cmd == "help" || cmd == "HELP")
        {
            Debug.Log("---");
            Debug.Log("Komennot:");
            Debug.Log("---");
            Debug.Log("help");
            Debug.Log("loadscene (numero)");
            Debug.Log("close");
            Debug.Log("clear");
            Debug.Log("reload");
//            Debug.Log("disableui");
            Debug.Log("---");
        }



        else if (cmd == "close" || cmd == "CLOSE")
        {
            PlayerPrefs.SetInt("ConsoleEnabled", 0);

            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

            #else
		    Application.Quit();

            #endif
        }



        else if (cmd == "debugcam" || cmd == "DEBUGCAM")
        {

        }



        else if (cmd == "clear" || cmd == "CLEAR")
        {
            consoleScript.Clear();
        }



        else if (cmd == "reload" || cmd == "RELOAD")
        {
            functions.LoadScene(functions.currentScene);
        }



        else if (cmd == "loadscene 0" || cmd == "LOADSCENE 0")
        {
            functions.LoadScene(0);
            Time.timeScale = 1;
        }
        else if (cmd == "loadscene 1" || cmd == "LOADSCENE 1")
        {
            functions.LoadScene(1);
            Time.timeScale = 1;
        }
        else if (cmd == "loadscene 2" || cmd == "LOADSCENE 2")
        {
            functions.LoadScene(2);
            Time.timeScale = 1;
        }
        else if (cmd == "loadscene 3" || cmd == "LOADSCENE 3")
        {
            functions.LoadScene(3);
            Time.timeScale = 1;
        }


        /*
        else if (cmd == "disableui" || cmd == "DISABLEUI") //mitäs sitten kun konsoli lähtee
        {
            disableUIScript.DoIt();
        }*/




        else
        {
            Debug.Log("<color=yellow>Komento (" + cmd + ") on virheellinen</color>");
        }
    }
}
