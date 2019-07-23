using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.UI;

public class PackageController : MonoBehaviour
{
    public EquipListView equiplistView;
    public Text Num;
    private int kucun = 200;

    public string EquipPos;
    public RowHeroDate EquipHero;

    //public InputField search;
    //public List<MergeEquipData> searchData;
    private PlayerData data;
    private List<RowEquipment> finalData;

    public int Choice;

    public void ShowPackage()
    {
        DynamicDataModel.Init();

        data = DynamicDataModel.ReadData();
        //Debug.Log("玩家数据" + JsonMapper.ToJson(data));
        Num.text = data.equips.Count + "/" + kucun;
        finalData = StaticDataModel.ReadEquipMerge(data.equips);

        equiplistView.DisPlay_Choice(finalData, this, Choice);
    }

    private RowEquipment selectedData;
    private EquipInfoView equipInfo;
    private GameObject mesage;

    public void EquipCellClick(RowEquipment data)
    {
        selectedData = data;
        GameObject go = PrefabsTwo.Load("Prefabs/equipInfo", transform);
        mesage = go;
        equipInfo = go.GetComponent<EquipInfoView>();
        equipInfo.Display(selectedData, this);
    }

    public void WearEquip(RowEquipment date)
    {
        string json = PlayerPrefs.GetString("HeroData");
        List<DynamicDate> HeroD = JsonMapper.ToObject<List<DynamicDate>>(json);

        switch (EquipPos)
        {
            case "W":
                for (int i = 0; i < HeroD.Count; i++)
                {
                    if (HeroD[i].HeroID == EquipHero.HeroID)
                    {
                        HeroD[i].WID = date.equipmentID;
                        
                    }
                }
                break;

            case "E1":
                for (int i = 0; i < HeroD.Count; i++)
                {
                    if (HeroD[i].HeroID == EquipHero.HeroID)
                    {
                        HeroD[i].EID_1 = date.equipmentID;
                    }
                }
                break;

            case "E2":
                for (int i = 0; i < HeroD.Count; i++)
                {
                    if (HeroD[i].HeroID == EquipHero.HeroID)
                    {
                        HeroD[i].EID_2 = date.equipmentID;
                    }
                }
                break;
        }
        string newJosn = JsonMapper.ToJson(HeroD);
        PlayerPrefs.SetString("HeroData", newJosn);

        List<RowHeroDate> newList= DynamicDataModel.ReadHeroData();
        for (int i = 0; i < newList.Count; i++)
        {
            if (EquipHero.PackageID==newList[i].PackageID)
            {
                EquipHero = newList[i];
                TeamModel.ChangeHeroSelf(EquipHero);
            }
        }

        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/PlayerInfo"));
        go.transform.SetParent(GameObject.Find("UI/Canvas").transform);
        (go.transform as RectTransform).localScale = Vector3.one;
        (go.transform as RectTransform).localPosition = Vector3.zero;
        (go.transform as RectTransform).offsetMax = Vector2.zero;
        (go.transform as RectTransform).offsetMin = Vector2.zero;
        go.GetComponent<PlayerInfoView>().Str_DisPlay(EquipHero);

        //GameObject.Find("UI/Canvas/chuanwu").GetComponent<ChuanwuListView>().Show();

        Destroy(gameObject);
    }

    public void EquipSellClick(EquipInfoView equipInfoView)
    {
        if (selectedData != null)
        {
            PlayerData playData = EquipModel.SellPlayerEquip(selectedData);
            finalData = StaticDataModel.ReadEquipMerge(playData.equips);
            equiplistView.DisPlay_Choice(finalData, this, 1);
            bool isContains = false;
            for (int i = 0; i < finalData.Count; i++)
            {
                if (finalData[i].equipmentID == selectedData.equipmentID && finalData[i].strLevel == selectedData.strLevel)
                {
                    isContains = true;
                    break;
                }
            }
            if (!isContains)
            {
                selectedData = null;
                Destroy(equipInfoView.gameObject);
                return;
            }
            Num.text = playData.equips.Count + "/" + kucun;
            equipInfoView.count.text = (selectedData.count - 1).ToString();
        }
    }

    public void BackMainMenu()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("MainMenu");
        Destroy(gameObject);
    }

    public void RankUPClick(EquipInfoView equipInfoView)
    {
        RowEquipment equipDate = selectedData;

        PlayerData newList = EquipModel.StrLevelUp(equipDate);
        finalData = StaticDataModel.ReadEquipMerge(newList.equips);

        equiplistView.DisPlay_Choice(finalData, this, 1);

        TeamModel.EquioStrChange();

        Num.text = newList.equips.Count + "/" + kucun;
        equipInfoView.Display(selectedData, this);
    }
}
