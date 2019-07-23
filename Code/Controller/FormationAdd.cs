﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FormationAdd : MonoBehaviour
{
    private FormationMenuController controller;

    private void Start()
    {
        controller = GameObject.Find("Canvas/FormationMain").GetComponent<FormationMenuController>();
    }

    public void OnClick()
    {
        ButtonSound.ButtonClickPlay();
        if (gameObject.name.Substring(gameObject.name.Length - 2, 1) == "F")
        {
            controller.AddFormation(1,0);
        }else
        {
            controller.AddFormation(0,0);
        }
    }
}
