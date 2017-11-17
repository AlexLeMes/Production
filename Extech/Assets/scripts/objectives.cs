﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectives : MonoBehaviour {

    public string currentObjectiveText;
    public string objectiveStatusText;
    public Text _objectiveText;

    public bool bombObjectiveActive = false;

    public bool objectiveComplete = false;

    public float bombObjectiveTime = 0f;

    public int currentObjectiveID = 0;

    public GameObject explostion;

    public GameObject successMenu;

    triggerObjective _objectiveTrigger;

    private void Awake()
    {
        explostion.SetActive(false);
        successMenu.SetActive(false);
    }

    private void Update()
    {
        _objectiveText.text = currentObjectiveText;

        if(bombObjectiveActive && bombObjectiveTime > 0)
        {
            bombObjectiveTime -= Time.deltaTime;
            _objectiveText.text = currentObjectiveText + " [TIME LEFT: " + bombObjectiveTime.ToString("F2") + "]";
		}

        if(!objectiveComplete && bombObjectiveTime <= 0)
        {
            bombObjectiveFailed();
        }
        else if(objectiveComplete && bombObjectiveTime > 0)
        {
            bombObjectiveSuccess();
        }
    }

    public void bombObjectiveFailed()
    {
        explostion.SetActive(true);
    }

    public void bombObjectiveSuccess()
    {
        successMenu.SetActive(true);
        // manger set time scale to 0 here
    }

    public void updateObjective(string objectiveText, int id)
    {
        currentObjectiveText = objectiveText;

        currentObjectiveID = id;
    }

    /*
    public void modText(string text)
    {
        currentObjectiveText = text;
    }
    */

    public void toggleBombObjective(float time)
    {
        bombObjectiveTime = time;

        bombObjectiveActive = true;
    }



    private void OnTriggerEnter(Collider other)
    {
        //bool status = false;

        if(other.gameObject.tag == "objective")
        {
            _objectiveTrigger = other.gameObject.GetComponent<triggerObjective>();

            //status = true;

            if (_objectiveText != null)
            {
                _objectiveTrigger.completeObjective(currentObjectiveID);
            }
        }
    }

}
