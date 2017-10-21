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
    playerStats _playerStats;

    public GameObject console;  //CHANGE TO TO TALK TO GAME MANGER - WHEN MADE AN INSTANCE
    [Space(10)]

    [Header("PLAYER SPEEDS")]
    //PLAYER MOVE SPEED
    public float moveSpeed = 5f;
    public float lookatRotateSpeed = 0.1f;
    public float rotateSpeed = 125f;
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

    void Update ()
    {
        //PLAYER KEY INPUT MOVEMENT//
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * moveSpeed *Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotateSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && canBoost == true)
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
