using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour {

    public player player;
    private keycard _keycard;

    public float healAmmount = 5;
    public int ammoType = 0; // 0 = gas   --- plasma is infinite, so no ID for it
    public int ammoToGive = 0;
    public int cardID;

    public bool healthPickup = false;
    public bool ammoPickup = false;
    public bool keycard = false;
   
    public void Awake()
    {
        player = gameObject.GetComponent<player>();
    }


   public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<player>() != null)
        {
            Debug.Log("pickup - hit player");

            if (healthPickup == true && player != null)
            {
                player.heal(healAmmount);
                healthPickup = false;
                Debug.Log("yes");
            }
            else
            {
                return;
            }
                //player.heal(healAmmount);


               
            
            if(ammoPickup)
            {
                //player.giveAmmo(ammoToGive, ammoType);
                player = other.gameObject.GetComponent<player>();

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
