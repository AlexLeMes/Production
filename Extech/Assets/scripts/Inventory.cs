using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public Image[] itemsimage = new Image[itemslots];
    public item[] items = new item[itemslots];
    public const int itemslots = 4;


    public void add(item itemadd)
    {
        for(int i=0; i < items.Length; i++)
        {
            if (items[i] == null)
            {
                items[i] = itemadd;
                itemsimage[i] = itemadd.itemimage;
                itemsimage[i].enabled = true;
            }
        }

    }
    public void remove(item itemremove)
    {
        for(int i=0; i<items.Length; i++)
        {
            if (items[i] ==itemremove)
            {
                items[i] = null;
                itemsimage[i] = null;
                itemsimage[i].enabled = false;
            }
        }
    }

}

