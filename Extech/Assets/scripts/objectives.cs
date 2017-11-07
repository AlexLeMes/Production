using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectives : MonoBehaviour {

    public string objectTiveText;
    public Text objText;

    public bool isActive = false;

    public bool objectiveComplete = false;

    public float objectiveTime = 0f;

    public GameObject explostion;

    public GameObject successMenu;

    private void Awake()
    {
        explostion.SetActive(false);
        successMenu.SetActive(false);

    }

    private void Update()
    {
        objText.text = objectTiveText;

        if(isActive && objectiveTime <= 0)
        {
            objectiveTime -= Time.deltaTime;
            objText.text = objectiveTime.ToString() + objectTiveText;
		}

        if(!objectiveComplete && objectiveTime <= 0)
        {
            failedObjective();
        }
        else if(objectiveComplete && objectiveTime > 0)
        {
            succesfulObjective();
        }
    }

    public void failedObjective()
    {
        explostion.SetActive(true);
    }

    public void succesfulObjective()
    {
        successMenu.SetActive(true);
        // manger set time scale to 0 here

    }

    public void modText(string text)
    {
        objectTiveText = text;
    }

}
