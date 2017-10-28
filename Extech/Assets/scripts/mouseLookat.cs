using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLookat : MonoBehaviour {
    /*
      TODO:

  */

    //no longer using?






    public Vector3 mousesensitivity;
    
    private float sensetivity;
    Vector3 position;
    Vector3 direction;
    float angle;
    private void Update()
    {
        sensetivity = 5;
        
       

        // i just leart this so if u have any problems understandin let me know ill try to explain it to the best of my ablity if the comments didnt 

        // self explainatory
         position = Camera.main.WorldToScreenPoint(transform.position);
        // we get the direction of where the mouse input postion is from the camera and that gives us a direction, i divided the inputposition to decrease the speed of roation 
         direction = (Input.mousePosition/2f ) - position;
        //Mathf.lerp goes interpolates through values and will change from ur from to ur to and gets the half of them so from 0 to 1 the result will be 0.5
         angle = Mathf.Lerp(direction.x, direction.y,direction.z); 
        //quaternion.angleaxis creats a relative rotation around ur coordiante and vector3.up is how u rotate 
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
       
        



       


    }
    
}
