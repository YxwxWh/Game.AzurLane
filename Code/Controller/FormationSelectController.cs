using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;

public class FormationSelectController : MonoBehaviour
{
    public RowHeroDate selectHeroInfo;
    public RowHeroDate heroInfo;
    public int pos;//0:前排 1:后排
    public int type;//0:编队 1:详情
    public Text SelectNum;

    void Start ()
    {
        transform.GetComponent<ForamationSelectListView>().DisPlay(this, pos, heroInfo);
    }

    /// <summary>
    /// 返回编队页面
    /// </summary>
    public void BackToFormation()
    {
        ButtonSound.ButtonClickPlay();
        GameObject go = PrefabsTwo.LoadUI("Prefabs/FormationMain");
        go.GetComponent<FormationMenuController>().type = type;
        Destroy(gameObject);
    }

    /// <summary>
    /// 确认更换或添加英雄
    /// </summary>
    public void OKClick()
    {
        ButtonSound.ButtonClickPlay();
        if (selectHeroInfo != null)
        {
            if (heroInfo == null)
            {
                TeamModel.Add(selectHeroInfo);
            }
            else
            {
                TeamModel.Change(heroInfo, selectHeroInfo);
            }
        }
        BackToFormation();
    }

    /// <summary>
    /// 离队
    /// </summary>
    public void LeaveTeam()
    {
        TeamModel.Leave(heroInfo);
        BackToFormation();
    }

    /// <summary>
    /// 返回建造页面
    /// </summary>
    public void BackToBuild()
    {
        ButtonSound.ButtonClickPlay();
        GameObject go = PrefabsTwo.LoadUI("Prefabs/Lottery");
        Destroy(gameObject);
    }

    /// <summary>
    /// 退役
    /// </summary>
    public void RetireOKClick()
    {
        if (selectHeroInfo != null)
        {
            string json = PlayerPrefs.GetString("HeroData");
            List<DynamicDate> date = JsonMapper.ToObject<List<DynamicDate>>(json);
            for (int i = 0; i < date.Count; i++)
            {
                if (date[i].PackageID == selectHeroInfo.PackageID)
                {
                    date.RemoveAt(i);
                }
            }
            Prefabs.Alert("退役成功", null);
            string NewDate = JsonMapper.ToJson(date);
            PlayerPrefs.SetString("HeroData", NewDate);
        }
        BackToBuild();
    }
}
