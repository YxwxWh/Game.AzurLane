using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class info : MonoBehaviour {
    private AudioSource audioS;
    private Slider BGMvolume;
	
	void Start () {
        audioS = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        BGMvolume =transform.Find("seting/SoundSeting/BGM_Slider").GetComponent<Slider>();
        BGMvolume.value = audioS.volume;

    }
    public void OnClick() {
        Destroy(gameObject);
        PrefabsTwo.LoadUI("MainMenu");


    }

    public void Zhuxiao() {
        //audioS.Stop();

        //Destroy(GameObject.Find("Canvas/Main"));
        //GameObject.Find("boot(Clone)").GetComponent<BootStart>().Logout();
        //audioS.Play();

        //Prefabs.LoadGameObject("Prefab/LoadScene");
        Prefabs.SceneSwitch("Scene/Boot", null);
    }
    public void Volume() {
        audioS.volume = BGMvolume.value;

    }

    public void ButtonClick()
    {
        ButtonSound.ButtonClickPlay();
    }
	
}
