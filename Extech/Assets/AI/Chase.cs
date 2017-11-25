using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Node
{


    public override void Execute()
    {
        Vector3 targetDir = BT.player.transform.position - BT.transform.position;
        Physics.Raycast(BT.transform.position, targetDir.normalized, out BT.hit);
         Debug.DrawRay(BT.transform.position, BT.player.transform.position - BT.transform.position, Color.red);

        //Debug.Log(BT.hit);

        


        
        
       
        BT.angle = Vector3.Angle(targetDir,BT.transform.forward);
        


        if (Vector3.Distance(BT.transform.position, BT.player.transform.position) < BT.maxdistance || BT.angle <= BT.vision && BT.hit.collider.tag=="Player" )
        {
            BT.playerspotted = true;
            BT.transform.LookAt(BT.player.transform.position);
            BT.waypoint = false;
            BT.canmove = true;

            BT.transform.position = Vector3.MoveTowards(BT.transform.position, BT.player.transform.position, BT.speed);
            state = Node_State.success;
            Debug.Log("chase" + state);



        }
        
        
        else
        {
            BT.waypoint = true;
            BT.canmove = false;
            state = Node_State.faliure;

        }
        










    }
   
}
