using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour {

    public float health =1f;
    public float stamina = 1f;
    public float moveSpeed = 0f;
    public float rotateSpeed = 0f;
    public float boostSpeed = 0f;
    public bool alive = true;

    public void takeDamage(float damage)
    {
        health -= damage;
    }
    public void heal(float healing)
    {
        health += healing;
    }
}
