using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStart : MonoBehaviour {
    
	void Awake () {
        Clean();
        DynamicDataModel.Init();
    }

    public void Clean()
    {
        PlayerPrefs.DeleteAll();
    }
}
