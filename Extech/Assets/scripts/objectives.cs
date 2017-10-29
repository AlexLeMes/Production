using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectives : MonoBehaviour {

    public string objectTiveText;
    public Text objText;

    public bool isActive = false;

    public float objectiveTime = 0f;

    private void Update()
    {
        objText.text = objectTiveText;

        if(isActive == true && objectiveTime < 0)
        {
            objectiveTime -= Time.deltaTime;
            objText.text = objectiveTime.ToString() + objectTiveText;
		}
    }

    public void modText(string text)
    {
        objectTiveText = text;
    }

}
