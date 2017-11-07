using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance = null;

    /*
        TODO:
            //SET-UP SINGLETON
    */

    public GameObject console;
    public weapon _weapon;
    //EDIT THESE WHEN MADE INSTANCE

    GameObject player;

    public GameObject spawnPoint;
    Vector3 spawnLocation;

    bool isPaused = false;

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)
        {
            //if not, set instance to this
            instance = this;
        }
        //If instance already exists and it's not this:
        else if (instance != this)
        {
            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
            Destroy(gameObject);
        }
        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start ()
    {
        spawnLocation = spawnPoint.transform.position;

        console.SetActive(false);

        respawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("PAUSE_GAME");
            pauseGame();
        }
    }

    public void respawn()
    {
        player.transform.position = spawnLocation;
    }

    public void restartLevel()
    {

    }

    public void pauseGame()
    {
        if(Time.timeScale < 1)
        {
            Time.timeScale = 1;
        }
        else if(Time.timeScale >= 1)
        {
            Time.timeScale = 0;
        }
    }

    
    public void debugAddAmmo()
    {
        _weapon.ammo += 50;
    }
    
}
