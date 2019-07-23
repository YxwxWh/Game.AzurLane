using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public static class DynamicDataModel
{
    private static string key = "UserData";

    private static string Herokey = "HeroData";
    public static void Init()
    {
        if (PlayerPrefs.GetString(key) == "")
        {
            TextAsset ta = Resources.Load<TextAsset>("LocalData/PlayerData");
            PlayerPrefs.SetString(key, ta.text);     
        }
        if (PlayerPrefs.GetString(Herokey) == "")
        {
            TextAsset HeroDynamicDate = Resources.Load<TextAsset>("LocalData/HeroDynamicDate");      
            PlayerPrefs.SetString(Herokey, HeroDynamicDate.text);
        }
    }

    public static PlayerData ReadData()
    {
        string json = PlayerPrefs.GetString(key);
        PlayerData playerData = JsonMapper.ToObject<PlayerData>(json);

       // Debug.Log("角色数据" + json);
        return playerData;
    }

    public static List<RowHeroDate> ReadHeroData()
    {
        string json = PlayerPrefs.GetString(Herokey);
        List<DynamicDate> date = JsonMapper.ToObject<List<DynamicDate>>(json);

        //20190627 start
        //string Ejson = PlayerPrefs.GetString(key);
        //PlayerData Edate = JsonMapper.ToObject<PlayerData>(Ejson);
        PlayerData Edate = ReadData();
        //20190627 end

        List<RowHeroDate> row = StaticDataModel.ReadHeroDate(date, Edate);

        string json1 = JsonMapper.ToJson(row);
       // Debug.Log("Hero数据" + json1);
        return row;
    }
}
