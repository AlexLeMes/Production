using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

/*
    TODO:
        - set the player to only be able to move when
        the mouse position is a certain distance away from the player
*/
    character _character;

    public GameObject console;  //CHANGE TO TO TALK TO GAME MANGER - WHEN MADE AN INSTANCE
    [Space(10)]

    [Header("PLAYER SPEEDS")]
    //PLAYER MOVE SPEED
    float moveSpeed = 1f;
    float rotateSpeed = 1f;
    float boostSpeed = 1f;
    [Space(10)]

    [Header("PLAYER UI ELEMENTS")]
    public Slider healthBar;
    public Slider staminaBar;

    bool canMove = true;
    bool moving = false;
    bool canBoost = true;
    bool boosting = true;

    private void Awake()
    {
        _character = this.gameObject.GetComponent<character>();
    }

    private void Start()
    {
        moveSpeed = _character.moveSpeed;
        rotateSpeed = _character.rotateSpeed;
        boostSpeed = _character.boostSpeed;
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
            //_playerStats.decreasestamina();
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
        /*
        if (Stamina < maxStamina)
        {
            canMove = false;
            Stamina += 0.05f * Time.deltaTime;
        }

        if (Stamina <= 0.1f)
        {
            canBoost = false;
        }
        else if(Stamina > 0.5f)
        {
            canBoost = true;
        }
        */
        //CONSOLE with `
        if (Input.GetKeyDown(KeyCode.C))
        {
            console.SetActive(!console.activeSelf);
        }
    }

    public void die()
    {
        //PLAYER DEATH LOGIC HERE
    }
}