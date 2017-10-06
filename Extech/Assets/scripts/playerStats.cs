using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class playerStats : MonoBehaviour {

    [Header("PLAYER STATS")]
    public float maxHealth = 1f;
    public float PlayerHealth = 1f;
    //public Image PlayerHealthBar;
    public Slider healthBar;
    public float maxStamina = 1f;
    public float PlayerStamina = 1f;
    //public Image PlayerStaminaBar;
    public Slider staminaBar;


    public bool canmove = true;

    // Update is called once per frame
    void Update()
    {
        staminaBar.value = PlayerStamina;
        healthBar.value = PlayerHealth;

        //PlayerStaminaBar.fillAmount = PlayerStamina / maxStamina;

        /*
        if (PlayerStamina > 0)
        {
            canmove = true;
        }
        if (Input.GetKey(KeyCode.W) && canmove == true && PlayerStamina > 0)
        {
            transform.Translate(0.1f, 0, 0);
            decreasestamina();

        }
        else if (Input.GetKey(KeyCode.S) && canmove == true && PlayerStamina > 0)
        {
            transform.Translate(-0.1f, 0, 0);
            decreasestamina();

        }
        else if (Input.GetKey(KeyCode.D) && canmove == true && PlayerStamina > 0)
        {
            transform.Translate(0, 0, 0.1f);
            decreasestamina();

        }
        else if (Input.GetKey(KeyCode.A) && canmove == true && PlayerStamina > 0)
        {
            transform.Translate(0, 0, -0.1f);
            decreasestamina();

        }
       
        if (PlayerStamina != 100)
        {
            canmove = false;
            PlayerStamina++;
        }
         */
    }

    public void decreasestamina()
    {
        PlayerStamina -= 0.3f * Time.deltaTime;

        if(PlayerStamina <= 0)
        {
            PlayerStamina = 0;
        }

        //PlayerStaminaBar.fillAmount = PlayerStamina / maxStamina;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("enemy_attack"))
        { 
            PlayerHealth -= 50;
            //PlayerHealthBar.fillAmount = PlayerHealth / maxHealth;
        }
        else if (PlayerHealth <= 0)
        {
            Debug.Log("playerDied");
        }
    }

    public void takeDamage(float damage)
    {
        PlayerHealth -= damage;
    }
}

