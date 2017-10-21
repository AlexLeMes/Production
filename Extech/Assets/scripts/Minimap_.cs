using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Minimap_ : MonoBehaviour
{
    public TextAsset level;
    string readline;
    public GameObject[] levelobjects; // making an array of objects to be later instantiated.
    float x;
    float y;

    // Use this for initialization
    void Start()
    { // this function will instantiate the game objects into the scene following the text file in the game manager.

        //using (StringReader SR = new StringReader(level.text))
        {
           // while ((readline = SR.ReadLine()) != null)  // to instantiate the objects as long as there is text present.
            {
               // foreach (char C in readline)
                {
                    //switch (C)
                    //{
                       // case '0': // the path of the creeps
                            Instantiate(levelobjects[0], new Vector3(x, y, 0), Quaternion.identity);

                            //break;
                        //case '1': // the walls
                            Instantiate(levelobjects[1], new Vector3(x, y, 0), Quaternion.identity);
                          //  break;
                       // case '2': // the player

                            Instantiate(levelobjects[2], new Vector3(x, y, -0.1f), Quaternion.identity);
                           // break;
                       // case '3': // the base

                            Instantiate(levelobjects[3] , new Vector3(x, y, 0), Quaternion.identity);
                           // break;
                       // case '4': // creeps

                            Instantiate(levelobjects[4], new Vector3(x, y, 0), Quaternion.identity);
                           // break;
                       // case '5': // waypoint1 

                            Instantiate(levelobjects[5], new Vector3(x, y, -0.1f), Quaternion.identity);
                           // break;
                        //case '6': // waypoint2

                            Instantiate(levelobjects[6], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;
                        //case '7': //waypoint 3

                            Instantiate(levelobjects[7], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;
                       // case '8': //waypoint 4

                            Instantiate(levelobjects[8], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;
                        //case '9': //waypoint 5

                            Instantiate(levelobjects[9], new Vector3(x, y, -0f), Quaternion.identity);
                            //break;
                        //c//ase 'A': //waypoint 6

                            Instantiate(levelobjects[10], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;
                        //case 'B': //waypoint 7

                            Instantiate(levelobjects[11], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;
                       // case 'C': //Tower 2A

                            Instantiate(levelobjects[12], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;

                        //case 'D': //Tower 2B

                            Instantiate(levelobjects[13], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;
                       // case 'E': //Tower 2C

                            Instantiate(levelobjects[14], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;
                       // case 'F': //Tower 2D

                            Instantiate(levelobjects[15], new Vector3(x, y, -0f), Quaternion.identity);
                            //break;
                        //case 'G': //Tower 2E

                            Instantiate(levelobjects[16], new Vector3(x, y, -0f), Quaternion.identity);
                           // break;




                        //default: //incase there's an empty character in text.
                            Debug.Log("WARNING! There is nothing found");
                           // break;

                    }
                    x++;

                }
                y--;
                x = 0;
            }
        }
    }
//}
