using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
            case "restart game":
                //gameController.Instance.restartGame();
                Debug.Log("<color=purple>CONSOLE: restart game</color>");
                //MAKE THIS CODE WORK
                break;
            default:
                Debug.Log("<color=red>CONSOLE: UNKOWN COMMAND</color>");
                commandLine.text = "UNKOWN COMMAND";
                break;
        }
    }
}
