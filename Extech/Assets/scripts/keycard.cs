using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycard : MonoBehaviour {

    GameObject playerKeycard;

    int cardID = 0;

    GameObject door;
    door _door;
    pickupKeyCard card;

    public int[] storedCards;
    int storedCardPos = 0;   

    private void Start()
    {
        storedCards = new int[5];
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "door")
        {
            _door = other.gameObject.GetComponent<door>();

            for(int i = 0; i < storedCards.Length; i++)
            {
                cardID = storedCards[i];
                _door.accessDoor(cardID);
            }
        }

        if(other.gameObject.tag == "keycard")
        {
            card = other.gameObject.GetComponent<pickupKeyCard>();
            cardID = card.cardID;

            storedCards[storedCardPos] = cardID;

            Destroy(other.gameObject);
            storedCardPos++;
        }
    }
}
