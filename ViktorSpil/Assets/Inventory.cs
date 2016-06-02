﻿using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour
{
    public GameObject Aim;
	// Use this for initialization
	void Start ()
	{
	    Aim = transform.FindChild("Aim").gameObject;
	}

    public void ToggleAim()
    {
        if (Aim.activeSelf)
        {
            Aim.SetActive(false);
        }
        else
        {
             Aim.SetActive(true);
        }
    }

    // Update is called once per frame
	void Update () {
	
	}
}