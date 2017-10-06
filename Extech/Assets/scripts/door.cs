using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

    public int doorID = 0;

    public void accessDoor(int cardID)
    {
        if(cardID == doorID)
        {
            openDoor();
            Debug.Log("openDoor");
        }
        else if (cardID != doorID)
        {
            invalidKey();
            Debug.Log("invalidKeycardID");
        }
    }

    public void openDoor()
    {
        //open door animation here

        //PROTOTYPE DESTORYS DOOR
        Destroy(this.gameObject);
    }
    public void invalidKey()
    {
        //insert invalid player key access here
    }
}
