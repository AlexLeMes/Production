using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class debug : MonoBehaviour {

    public InputField commandLine;
    string command;

    public GameObject managerObj; //CHANGE THIS WHEN MADE AN INSTANCE
    GameController gameController;

    private void Awake()
    {
        gameController = managerObj.GetComponent<GameController>();
    }

    public void clearCommandLine()
    {
        commandLine.text = "";
    }

    public void checkCommand()
    {
        command = commandLine.text;

        switch (command)
        {
            case "add ammo":
                Debug.Log("<color=purple>CONSOLE: add ammo</color>");
                gameController.debugAddAmmo();
                //MAKE THIS CODE WORK
                break;
            case "restart level":
                Debug.Log("<color=purple>CONSOLE: restart level</color>");
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
                //MAKE THIS CODE WORK
                break;
            case "restart game":
                Debug.Log("<color=purple>CONSOLE: restart game</color>");
                SceneManager.LoadScene(0);
                break;
            default:
                Debug.Log("<color=red>CONSOLE: UNKOWN COMMAND</color>");
                commandLine.text = "UNKOWN COMMAND";
                break;
        }
    }
}
