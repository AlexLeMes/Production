using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunLookat : MonoBehaviour {
    /*
  TODO:

*/

    public GameObject player;
    mouseLookat _mouseLookat;
    Transform target;

    public bool canShoot = false;
    bool lookat = true;
    float shootDistance = 5f;

    private void Awake()
    {
        _mouseLookat = player.gameObject.GetComponent<mouseLookat>();
    }

    // Use this for initialization
    void Start ()
    {
        target = _mouseLookat.target;
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 targetPostition = new Vector3(target.position.x, target.position.y, target.position.z);

        if (lookat == true)
        {
            transform.LookAt(targetPostition);
        }

        shootDistance = Vector3.Distance(targetPostition, transform.position);

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
