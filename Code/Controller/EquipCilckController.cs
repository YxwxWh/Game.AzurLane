using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipCilckController : MonoBehaviour {

    public PlayerInfoView pl;
    public void OpenPackage()
    {
        pl.OpenPackage(gameObject.name);
   
    }
}
