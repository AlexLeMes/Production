using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLookat : MonoBehaviour {
    /*
      TODO:

  */

    public Camera _camera;

    public Vector3 position;

    void Update()
    {
        Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f);
        position = _camera.ScreenToWorldPoint(position);
    }
    
}
