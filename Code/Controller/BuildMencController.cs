using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class BuildMencController : MonoBehaviour
{

    public Text gold, oil, diamond;

    void Start()
    {
        ShowPlayerInfo();
    }

    public void BackToMain()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("MainMenu");
        Destroy(gameObject);
    }
    public void Build()
    {
        ButtonSound.ButtonClickPlay();
        string json = PlayerPrefs.GetString("HeroData");
        List<DynamicDate> date = JsonMapper.ToObject<List<DynamicDate>>(json);

        switch (Random.Range(1, 5))
        {
            case 1:
                DynamicDate NewOne = new DynamicDate(1001, 1, 4, 10, 0, 0, 0, date[date.Count - 1].PackageID + 1);
                date.Add(NewOne);
                break;

            case 2:
                DynamicDate NewOne1 = new DynamicDate(1002, 1, 4, 10, 0, 0, 0, date[date.Count - 1].PackageID + 1);
                date.Add(NewOne1);
                break;

            case 3:
                DynamicDate NewOne2 = new DynamicDate(5001, 1, 3, 10, 0, 0, 0, date[date.Count - 1].PackageID + 1);
                date.Add(NewOne2);
                break;

            case 4:
                DynamicDate NewOne3 = new DynamicDate(3001, 1, 3, 10, 0, 0, 0, date[date.Count - 1].PackageID + 1);
                date.Add(NewOne3);
                break;

            case 5:
                DynamicDate NewOne4 = new DynamicDate(4002, 1, 3, 10, 0, 0, 0, date[date.Count - 1].PackageID + 1);
                date.Add(NewOne4);
                break;
        }


        Prefabs.Alert("Completion of Draw!", null);
        string NewDate = JsonMapper.ToJson(date);
        PlayerPrefs.SetString("HeroData", NewDate);
    }

    public void OpenToRetire()
    {
        ButtonSound.ButtonClickPlay();
        GameObject go = PrefabsTwo.LoadUI("Prefabs/RetireSelect");
        go.GetComponent<FormationSelectController>().pos = 3;
        Destroy(gameObject);
    }

    public void ShowPlayerInfo()
    {
        PlayerData pd = DynamicDataModel.ReadData();
        gold.text = pd.gold.ToString();
        oil.text = pd.oil.ToString();
        diamond.text = pd.diamond.ToString();
    }

    public void StageClick()
    {
        ButtonSound.ButtonClickPlay();
        if (TeamModel.IsAttack())
        {
            Prefabs.SceneSwitch("BattleField2", null);
        }
        else
        {
            Prefabs.Alert("编队前后排都要有角色!", null);
        }
    }

    public void StageC2lick()
    {
        ButtonSound.ButtonClickPlay();
        if (TeamModel.IsAttack())
        {
            Prefabs.SceneSwitch("BattleField3", null);
        }
        else
        {
            Prefabs.Alert("编队前后排都要有角色!", null);
        }
    }

    public void ButtonClick()
    {
        ButtonSound.ButtonClickPlay();
    }
}
