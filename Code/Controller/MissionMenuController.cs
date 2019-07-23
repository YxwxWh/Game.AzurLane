using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionMenuController : MonoBehaviour {

	
	void Start () {
		
	}

    public void BackToMain()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("MainMenu");
        Destroy(gameObject);
    }

    public void ButtonClick()
    {
        ButtonSound.ButtonClickPlay();
    }
}
