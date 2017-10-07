using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

/*
    TODO:
        - set the player to only be able to move when
        the mouse position is a certain distance away from the player
*/
    mouseLookat _mouseLookat;
    Transform target;
    playerStats _playerStats;

    public GameObject console;  //CHANGE TO TO TALK TO GAME MANGER - WHEN MADE AN INSTANCE
    [Space(10)]

    [Header("PLAYER SPEEDS")]
    //PLAYER MOVE SPEED
    public float moveSpeed = 5f;
    public float rotateSpeed = 2f;
    public float boostSpeed = 10f;

    bool canMove = true;
    bool moving = false;
    bool canBoost = true;
    bool boosting = true;

    private void Awake()
    {
        //mouseLookat script
        _mouseLookat = this.gameObject.GetComponent<mouseLookat>();
        _playerStats = this.gameObject.GetComponent<playerStats>();
    }

    private void Start()
    {
        //LOOKAT MOVEMENT TARGET - FROM mouseLookat script
        target = _mouseLookat.target;
    }

    void Update ()
    {
        //PLAYER LOOK AT MOVEMENT//

        //LOOKAT TARGET = THE LOOKAT OBJECTS X AND Z BUT USING THE PLAYERS Y POSITION
        //SO THAT THE PLAYER ONLY ROTATES ON THE Y AXIS
        Vector3 targetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        //MOVING THE PLAYER TO LOOKAT THE TARGET POSITION
        transform.LookAt(targetPostition);


        //PLAYER KEY INPUT MOVEMENT//
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed *Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        /*
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        */

        if(Input.GetKey(KeyCode.LeftShift) && canBoost == true)
        {
            moveSpeed = boostSpeed;
            _playerStats.decreasestamina();
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 5f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("PAUSE_GAME");
            //REFERNCE GAME MANGER TO PAUSE GAME
        }

        //PLAYER STATS//
        if (_playerStats.PlayerStamina < _playerStats.maxStamina)
        {
            //canMove = false;
            _playerStats.PlayerStamina += 0.05f * Time.deltaTime;
        }

        if (_playerStats.PlayerStamina <= 0.1f)
        {
            canBoost = false;
        }
        else
        {
            canBoost = true;
        }

        //CONSOLE with `
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            console.SetActive(!console.activeSelf);
        }
    }
}
