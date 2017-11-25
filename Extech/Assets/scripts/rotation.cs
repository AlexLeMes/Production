using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    public Camera cam;
    public float MaxX = 90;
    public float MinX = -90;

    float sensitivity = 200f;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        cam.transform.position = this.gameObject.transform.position;
        cam.transform.rotation = this.gameObject.transform.rotation;









        transform.localEulerAngles += new Vector3(-Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime, 0, 0);
        if (transform.localEulerAngles.x > MaxX &&  transform.localEulerAngles.x < 180)
        {
            transform.localEulerAngles = new Vector3(MaxX, 0, 0);
        }
        if (transform.localEulerAngles.x < MinX && transform.localEulerAngles.x > 180)
        {
            transform.localEulerAngles = new Vector3(MinX, 0, 0);
        }

    }
}
