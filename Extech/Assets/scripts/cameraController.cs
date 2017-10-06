using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    GameObject player;
    Transform pTrans;

    Vector3 playerPos;
    Vector3 gotoPos;
    public float smoothing = 0.1f;
    private Vector3 velocity = Vector3.zero;

    public Vector3 offset;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        pTrans = player.GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        playerPos = pTrans.transform.position + offset;
        gotoPos = Vector3.SmoothDamp(transform.position, playerPos, ref velocity, smoothing);
        transform.position = gotoPos;
    }     
}
