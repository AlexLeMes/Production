using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    /*
        TODO:
            //SET-UP SINGLETON
    */

    public GameObject console;
    public weapon _weapon;
    //EDIT THESE WHEN MADE INSTANCE

    void Start ()
    {
        console.SetActive(false);
    }
	
	
    public void pauseGame()
    {
        if(Time.timeScale == 0)
        {
            Time.timeScale = 1;

        }
        else if(Time.timeScale == 1)
        {
            Time.timeScale = 0;

        }
    }

    public void debugAddAmmo()
    {
        _weapon.ammo += 50;
    }
}
