using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickups : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "health")
        {
            Debug.Log("player_pickedup_health");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "ammo")
        {
            Debug.Log("player_pickedup_ammo");
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "special")
        {
            Debug.Log("player_pickedup_special");
            Destroy(other.gameObject);
        }
    }
}
