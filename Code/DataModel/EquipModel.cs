using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public static class EquipModel
{
    private static string key = "UserData";

    public static PlayerData SellPlayerEquip(RowEquipment data)
    {
        PlayerData player = DynamicDataModel.ReadData();
        for (int i = 0; i < player.equips.Count; i++)
        {
            Equip ep = player.equips[i];
            if (ep.equipmentID == data.equipmentID && ep.strLevel == data.strLevel)
            {
                ep.count -= 1;
                player.gold += data.price;
                if (ep.count == 0)
                {
                    player.equips.RemoveAt(i);

                }
                break;
            }

        }
        Prefabs.Alert("卖出" + data.name + "成功,获得金币" + data.price, null);
        PlayerPrefs.SetString(key, JsonMapper.ToJson(player));
        return player;
    }

    //public static PlayerData StrLevelUp(RowEquipment data)
    //{
    //    PlayerData player = ReadData();
    //    if (data.strLevel >= 10) {
    //        Prefabs.Alert("强化已满!", null);
    //        return player;
    //    }
    //    if (player.gold < data.price) {
    //        Prefabs.Alert("金币不足!", null);
    //        return player;
    //    }
    //    for (int i = 0; i < player.equips.Count; i++)
    //    {
    //        if (player.equips[i].equipmentID == data.equipmentID && player.equips[i].strLevel == data.strLevel)
    //        {
    //            player.equips[i].count -= 1;
    //            player.gold -= 200;

    //            if (player.equips[i].count == 0)
    //            {
    //                player.equips.RemoveAt(i);
    //            }
    //            break;
    //        }
    //    }

    //    bool isAdd = false;

    //    for (int i = 0; i < player.equips.Count; i++)
    //    {
    //        if (player.equips[i].equipmentID == data.equipmentID && player.equips[i].strLevel == data.strLevel + 1)
    //        {
    //            player.equips[i].count += 1;
    //            isAdd = true;
    //            break;
    //        }
    //    }
    //    if (!isAdd)
    //    {
    //        Equip equip = new Equip();
    //        equip.equipmentID = data.equipmentID;
    //        equip.count = 1;
    //        equip.strLevel = data.strLevel + 1;
    //        player.equips.Add(equip);
    //    }

    //    Prefabs.Alert("强化成功,消耗200物资", null);
    //    PlayerPrefs.SetString(key, JsonMapper.ToJson(player));
    //    return player;
    //}

    public static PlayerData StrLevelUp(RowEquipment data)
    {
        PlayerData player = DynamicDataModel.ReadData();
        if (data.strLevel >= 10)
        {
            Prefabs.Alert("强化已满!", null);
            return player;
        }
        if (player.gold < data.price)
        {
            Prefabs.Alert("金币不足!", null);
            return player;
        }
        for (int i = 0; i < player.equips.Count; i++)
        {
            if (player.equips[i].equipmentID == data.equipmentID)
            {
                player.gold -= 200;
                player.equips[i].strLevel += 1;
                break;
            }
        }

        Prefabs.Alert("强化成功,消耗200物资", null);
        PlayerPrefs.SetString(key, JsonMapper.ToJson(player));
        return player;
    }
}
