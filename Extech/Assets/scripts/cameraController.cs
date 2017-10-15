using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {
    /*
        TODO:
            
    */

    GameObject player;
    Transform pTrans;

    Vector3 playerPos;
    Vector3 gotoPos;
    public float smoothing = 0.1f;
    private Vector3 velocity = Vector3.zero;

    public Vector3 offset;
    //public Vector3 rotation;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        pTrans = player.GetComponent<Transform>();

        //transform.Rotate(rotation);
    }

    private void LateUpdate()
    {
        /*
        playerPos = pTrans.transform.position + offset;
        gotoPos = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smoothing);
        transform.position = gotoPos;
        */
        float direction = pTrans.transform.eulerAngles.y;
        Quaternion rotation = Quaternion.Euler(0, direction, 0);

        transform.position = pTrans.transform.position + rotation * offset;
        transform.LookAt(pTrans.transform);
    }     
}
