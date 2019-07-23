using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuanwuController : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void BackToMain()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("MainMenu");
        Destroy(gameObject);
    }
}
