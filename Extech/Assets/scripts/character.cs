using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

    weapon characterWeapon;

    public float health =1f;
    public float stamina = 1f;
    public bool alive = true;

    public float moveSpeed = 0f;
    public float rotateSpeed = 0f;
    public float boostSpeed = 0f;

    public float weaponOneAmmo = 0;

    public void Start()
    {
        characterWeapon = this.gameObject.GetComponent<weapon>();

        if (characterWeapon == null)
        {
            return;
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;
    }

    public void heal(float healing)
    {
        health += healing;
    }

    public void giveAmmo(float ammoammount, int ammoType)
    {
        weaponOneAmmo += ammoammount;
    }
}
