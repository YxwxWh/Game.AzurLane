using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class MainMenuContoller : MonoBehaviour {
    public Text oil;
    public Text gold;
    public Text diamond;

    void Start () {
        
        DynamicDataModel.Init();
        PlayerData data = DynamicDataModel.ReadData();
        oil.text = data.oil.ToString();
        gold.text = data.gold.ToString();
        diamond.text = data.diamond.ToString();
        Debug.Log("钻石"+data.diamond);
        //GameObject.Find("Canvas").GetComponent<BootStart>().enabled=false;
    }

    private void OnEnable()
    {
        Start();
    }
    public void PackegeOpen()
    {
        ButtonSound.ButtonClickPlay();
        GameObject go = PrefabsTwo.LoadUI("Prefabs/Packege");
        go.GetComponent<PackageController>().Choice = 1;
        go.GetComponent<PackageController>().ShowPackage();
        Destroy(gameObject);
    }
    public void BulidOpen()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("Prefabs/Lottery");
        Destroy(gameObject);
    }
    public void Chuanwu()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("Prefabs/chuanwu");
        Destroy(gameObject);
    }
    public void Formation()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("Prefabs/FormationMain");
        Destroy(gameObject);
    }

    public void MissionOpen()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("Prefabs/Mission");
        Destroy(gameObject);
    }

    public void SettingClick()
    {
        ButtonSound.ButtonClickPlay();

        PrefabsTwo.LoadUI("Prefabs/setting");
        Destroy(gameObject);

    }

    public void AttackClick()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("Prefabs/Fight");
        Destroy(gameObject);
    }

}
