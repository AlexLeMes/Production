using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLookat : MonoBehaviour {
    /*
  TODO:

*/

    public GameObject player;
    mouseLookat _mouseLookat;
    Vector3 target;

    public bool canShoot = false;
    bool lookat = true;
    float shootDistance = 5f;

    private void Awake()
    {
        _mouseLookat = player.gameObject.GetComponent<mouseLookat>();
    }

    void Start ()
    {
        //target = _mouseLookat.position;
    }
	
	void Update ()
    {
        //target = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0f);
        //transform.LookAt(target);

        if (lookat == true)
        {
            transform.LookAt(target);
        }

        shootDistance = Vector3.Distance(target, transform.position);

        if (shootDistance >= 5f)
        {
            canShoot = true;
            lookat = true;
        }
        else if (shootDistance < 5f)
        {
            canShoot = false;
            lookat = false;
        }
    }
}
