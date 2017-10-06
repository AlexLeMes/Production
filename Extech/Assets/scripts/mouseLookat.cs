using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLookat : MonoBehaviour {

    public Camera _camera;

    public Transform target;
    public Vector3 lookatLoc;

    //LOCATION OBJECT USED FOR PLAYER TO LOOK AT
    //NOTE: DISABLE THE TEXTURE FOR GAME RELEASE
    public GameObject locationObject;

    private void Update()
    {
        //RAYCASTING FROM THE MOUSE POSITION ON SCREEN
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            //SAVING RAYCAST HIT LOCATION AS aim
            lookatLoc = hit.point;
        }

        //MOVING THE LOCATION OBJECT USED FOR THE PLAYER TO LOOK AT
        //TO THE POSITION OF THE RAYCAST HIT
        locationObject.transform.position = new Vector3(lookatLoc.x, lookatLoc.y, lookatLoc.z);
        //SETTING THE PLAYERS LOOKAT TARGET AS THE LOCATION OBJECT
        target = locationObject.transform;
    }
}
