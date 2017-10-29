using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour {

    private character player;
    private keycard _keycard;

    public float healAmmount = 0;
    public int ammoType = 0; // 0 = gas   --- plasma is infinite, so no ID for it
    public int ammoToGive = 0;
    public int cardID;

    public bool healthPickup = false;
    public bool ammoPickup = false;
    public bool keycard = false;
   
    private void Awake()
    {
        player = this.gameObject.GetComponent<character>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("pickup - hit player");

            if(healthPickup)
            {
                //player.heal(healAmmount);
                player = other.gameObject.GetComponent<character>();

                if (player == null)
                {
                    return;
                }
                else
                {
                    player.heal(healAmmount);
                }
            }
            if(ammoPickup)
            {
                //player.giveAmmo(ammoToGive, ammoType);
                player = other.gameObject.GetComponent<character>();

                if (player == null)
                {
                    return;
                }
                else
                {
                    player.giveAmmo(ammoToGive, ammoType);
                }
            }
            if(keycard)
            {
                _keycard = other.gameObject.GetComponent<keycard>();

                if(_keycard == null)
                {
                    return;
                }
                else
                {
                    _keycard.keycardPickup(cardID);
                }
            }

            Destroy(this.gameObject);
        }
    }
}
