using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    /*
        TODO:
            //SET-UP SINGLETON
    */

    public GameObject console;

    void Start ()
    {
        console.SetActive(false);
    }
	
	
    public void pauseGame()
    {
        float time = Time.timeScale;

        if(time == 0)
        {
            Time.timeScale = 1;
            //REFERNCE INTERFACECONTROLLER TO TOGGLE PAUSE MENU

        }
        else if(time == 1)
        {
            Time.timeScale = 0;
            //REFERNCE INTERFACECONTROLLER TO TOGGLE PAUSE MENU

        }
    }
}
