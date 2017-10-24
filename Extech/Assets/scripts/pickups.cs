using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour {

    private wepaon weapons;
    public GameObject weapon;
    private character player;

    public float healAmmount = 0;
    public int ammoType = 0;
    public int ammo = 0;
   
    private void Awake()
    {
        weapons = weapon.gameObject.GetComponent<wepaon>();
        player = this.gameObject.GetComponent<character>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "health")
        {
            player.heal(healAmmount);
            Debug.Log("player_pickedup_health");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ammo")
        {
            weapons.ammo += 10;
            Debug.Log("player_pickedup_ammo");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "special")
        {
            Debug.Log("player_pickedup_special");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "gas")
        {
            weapons.gas += 50;
            Debug.Log("player_pickedup_gas");
            Destroy(other.gameObject);
        }
    }
}
