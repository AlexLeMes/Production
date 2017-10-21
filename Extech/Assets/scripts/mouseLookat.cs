using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLookat : MonoBehaviour {
    /*
      TODO:

  */

    public Camera _camera;

    public Vector3 position;
    

    public void FixedUpdate()
    {

          position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f);
          _camera.ScreenToWorldPoint(Input.mousePosition);
         Debug.Log(Input.mousePosition);
         
      

    }
    /*Update()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f);
        position = _camera.ScreenToWorldPoint(position);
    }
    */
}
