using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
public  class StaticDataModel  {

    public static List<RowEquipment> ReadEquipMerge(List<Equip> equipList) {
        TextAsset ta = Resources.Load<TextAsset>("LocalData/EquipStaticDate");
        List<Equipment> data = JsonMapper.ToObject<List<Equipment>>(ta.text);
        
        List<RowEquipment> finalData = new List<RowEquipment>();

        for (int i = 0; i < equipList.Count; i++)
        {
            for (int j = 0; j < data.Count; j++)
            {
                if (equipList[i].equipmentID == data[j].equipmentID)
                {
                    RowEquipment equip = new RowEquipment();

                    equip.equipmentID = data[j].equipmentID;
                    equip.icon = data[j].icon;
                    equip.name = data[j].name;
                    equip.type = data[j].type;
                    equip.color = data[j].color;

                    equip.shelling = data[j].shelling;
                    equip.lightningStrikes = data[j].lightningStrikes;
                    equip.airDefense = data[j].airDefense;
                    equip.aviation = data[j].aviation;
                    equip.filling = data[j].filling;
                    equip.miss = data[j].miss;
                    equip.durability = data[j].durability;
                    equip.atk = data[j].atk + 2 * equipList[i].strLevel;
                    equip.shotDeg = data[j].shotDeg;
                    equip.shotNumber = data[j].shotNumber;
                    equip.countTime = data[j].countTime;
                    equip.range = data[j].range;
                    equip.bt = data[j].bt;
                    equip.speed = data[j].speed;
                    equip.pierce = data[j].pierce;
                    equip.price = data[j].price;
                    equip.tier = data[j].tier;

                    equip.count = equipList[i].count;
                    equip.strLevel = equipList[i].strLevel;

                    finalData.Add(equip);
                    break;
                }
            }
        }

        return finalData;
    }

    //public static List<RowHeroDate> ReadHeroDate(List<DynamicDate> heroD, PlayerData EquipD)
    //{
    //    TextAsset HeroStaticDate = Resources.Load<TextAsset>("LocalData/HeroStaticDate");
    //    List<HeroDate> heroS = JsonMapper.ToObject<List<HeroDate>>(HeroStaticDate.text);

    //    TextAsset EquipStaticDate = Resources.Load<TextAsset>("LocalData/EquipStaticDate");
    //    List<Equipment> EquipS = JsonMapper.ToObject<List<Equipment>>(EquipStaticDate.text);


    //    List<RowHeroDate> finalDate = new List<RowHeroDate>();

    //    for (int i = 0; i < heroD.Count; i++)
    //    {
    //        RowHeroDate row = new RowHeroDate();
    //        for (int j = 0; j < heroS.Count; j++)
    //        {
    //            if (heroD[i].HeroID == heroS[j].HeroID)
    //            {
    //                row.HeroID = heroS[j].HeroID;
    //                row.Icon = heroS[j].Icon;
    //                row.Name = heroS[j].Name;
    //                row.Type = heroS[j].Type;
    //                row.PackageID = heroD[i].PackageID;

    //                row.Level = heroD[i].Level;
    //                row.Stars = heroD[i].Stars;

    //                row.Shelling = heroS[j].Shelling;
    //                row.LightningStrikes = heroS[j].LightningStrikes;
    //                row.AirDefense = heroS[j].AirDefense;
    //                row.Aviation = heroS[j].Aviation;
    //                row.Consumption = heroS[j].Consumption;
    //                row.Filling = heroS[j].Filling;
    //                row.Miss = heroS[j].Miss;
    //                row.Durability = heroS[j].Durability;
    //                row.ArmorType = heroS[j].ArmorType;
    //                row.ColorType = heroS[j].ColorType;
    //            }

    //        }

    //        #region 查找已穿戴装备
    //        for (int l = 0; l < EquipD.equips.Count; l++)
    //        {
    //            if (heroD[i].WID == EquipD.equips[l].equipmentID)
    //            {
    //                for (int k = 0; k < EquipS.Count; k++)
    //                {
    //                    #region 查找武器
    //                    if (EquipD.equips[l].equipmentID == EquipS[k].equipmentID)
    //                    {
    //                        RowEquipment newOne = new RowEquipment();
    //                        newOne.equipmentID = heroD[i].WID;
    //                        newOne.name = EquipS[k].name;
    //                        newOne.icon = EquipS[k].icon;
    //                        newOne.type = EquipS[k].type;
    //                        newOne.color = EquipS[k].color;
    //                        newOne.tier = EquipS[k].tier;

    //                        newOne.lightningStrikes = EquipS[k].lightningStrikes;
    //                        newOne.shelling = EquipS[k].shelling;
    //                        newOne.airDefense = EquipS[k].airDefense;
    //                        newOne.aviation = EquipS[k].aviation;
    //                        newOne.filling = EquipS[k].filling;
    //                        newOne.miss = EquipS[k].miss;
    //                        newOne.durability = EquipS[k].durability;

    //                        newOne.atk = EquipS[k].atk;
    //                        newOne.shotDeg = EquipS[k].shotDeg;
    //                        newOne.shotNumber = EquipS[k].shotNumber;
    //                        newOne.countTime = EquipS[k].countTime;
    //                        newOne.range = EquipS[k].range;
    //                        newOne.bt = EquipS[k].bt;
    //                        newOne.speed = EquipS[k].speed;
    //                        newOne.pierce = EquipS[k].pierce;
    //                        newOne.price = EquipS[k].price;

    //                        newOne.count = EquipD.equips[l].count;
    //                        newOne.strLevel = EquipD.equips[l].strLevel;

    //                        row.W = newOne;
    //                        break;
    //                    }
    //                    #endregion
    //                }
    //            }
    //            if (heroD[i].EID_1 == EquipD.equips[l].equipmentID)
    //            {
    //                for (int k = 0; k < EquipS.Count; k++)
    //                {
    //                    #region 查找设备1
    //                    if (EquipD.equips[l].equipmentID == EquipS[k].equipmentID)
    //                    {
    //                        RowEquipment newOne = new RowEquipment();
    //                        newOne.equipmentID = heroD[i].EID_1;
    //                        newOne.name = EquipS[k].name;
    //                        newOne.icon = EquipS[k].icon;
    //                        newOne.type = EquipS[k].type;
    //                        newOne.color = EquipS[k].color;
    //                        newOne.tier = EquipS[k].tier;

    //                        newOne.lightningStrikes = EquipS[k].lightningStrikes;
    //                        newOne.shelling = EquipS[k].shelling;
    //                        newOne.airDefense = EquipS[k].airDefense;
    //                        newOne.aviation = EquipS[k].aviation;
    //                        newOne.filling = EquipS[k].filling;
    //                        newOne.miss = EquipS[k].miss;
    //                        newOne.durability = EquipS[k].durability;

    //                        newOne.atk = EquipS[k].atk;
    //                        newOne.shotDeg = EquipS[k].shotDeg;
    //                        newOne.shotNumber = EquipS[k].shotNumber;
    //                        newOne.countTime = EquipS[k].countTime;
    //                        newOne.range = EquipS[k].range;
    //                        newOne.bt = EquipS[k].bt;
    //                        newOne.speed = EquipS[k].speed;
    //                        newOne.pierce = EquipS[k].pierce;
    //                        newOne.price = EquipS[k].price;

    //                        newOne.count = EquipD.equips[l].count;
    //                        newOne.strLevel = EquipD.equips[l].strLevel;

    //                        row.E1 = newOne;
    //                        break;
    //                    }
    //                    #endregion
    //                }
    //            }
    //            if (heroD[i].EID_2 == EquipD.equips[l].equipmentID)
    //            {
    //                for (int k = 0; k < EquipS.Count; k++)
    //                {
    //                    #region 查找设备2
    //                    if (EquipD.equips[l].equipmentID == EquipS[k].equipmentID)
    //                    {
    //                        RowEquipment newOne = new RowEquipment();
    //                        newOne.equipmentID = heroD[i].EID_2;
    //                        newOne.name = EquipS[k].name;
    //                        newOne.icon = EquipS[k].icon;
    //                        newOne.type = EquipS[k].type;
    //                        newOne.color = EquipS[k].color;
    //                        newOne.tier = EquipS[k].tier;

    //                        newOne.lightningStrikes = EquipS[k].lightningStrikes;
    //                        newOne.shelling = EquipS[k].shelling;
    //                        newOne.airDefense = EquipS[k].airDefense;
    //                        newOne.aviation = EquipS[k].aviation;
    //                        newOne.filling = EquipS[k].filling;
    //                        newOne.miss = EquipS[k].miss;
    //                        newOne.durability = EquipS[k].durability;

    //                        newOne.atk = EquipS[k].atk;
    //                        newOne.shotDeg = EquipS[k].shotDeg;
    //                        newOne.shotNumber = EquipS[k].shotNumber;
    //                        newOne.countTime = EquipS[k].countTime;
    //                        newOne.range = EquipS[k].range;
    //                        newOne.bt = EquipS[k].bt;
    //                        newOne.speed = EquipS[k].speed;
    //                        newOne.pierce = EquipS[k].pierce;
    //                        newOne.price = EquipS[k].price;

    //                        newOne.count = EquipD.equips[l].count;
    //                        newOne.strLevel = EquipD.equips[l].strLevel;

    //                        row.E2 = newOne;
    //                        break;
    //                    }
    //                    #endregion
    //                }
    //            }


    //        }
    //        #endregion
    //        finalDate.Add(row);
    //    }

    //    //Debug.Log(JsonMapper.ToJson(finalDate).ToString());

    //    return finalDate;

    //}
    public static List<RowHeroDate> ReadHeroDate(List<DynamicDate> heroD, PlayerData EquipD)
    {
        TextAsset HeroStaticDate = Resources.Load<TextAsset>("LocalData/HeroStaticDate");
        List<HeroDate> heroS = JsonMapper.ToObject<List<HeroDate>>(HeroStaticDate.text);

        //TextAsset EquipStaticDate = Resources.Load<TextAsset>("LocalData/EquipStaticDate");
        //List<Equipment> EquipS = JsonMapper.ToObject<List<Equipment>>(EquipStaticDate.text);

        List<RowEquipment> rowEquipList = ReadEquipMerge(EquipD.equips);

        List<RowHeroDate> finalDate = new List<RowHeroDate>();

        for (int i = 0; i < heroD.Count; i++)
        {
            RowHeroDate row = new RowHeroDate();
            for (int j = 0; j < heroS.Count; j++)
            {
                if (heroD[i].HeroID == heroS[j].HeroID)
                {
                    row.HeroID = heroS[j].HeroID;
                    row.Icon = heroS[j].Icon;
                    row.Name = heroS[j].Name;
                    row.Type = heroS[j].Type;
                    row.PackageID = heroD[i].PackageID;

                    row.Level = heroD[i].Level;
                    row.Stars = heroD[i].Stars;

                    row.Shelling = heroS[j].Shelling;
                    row.LightningStrikes = heroS[j].LightningStrikes;
                    row.AirDefense = heroS[j].AirDefense;
                    row.Aviation = heroS[j].Aviation;
                    row.Consumption = heroS[j].Consumption;
                    row.Filling = heroS[j].Filling;
                    row.Miss = heroS[j].Miss;
                    row.Durability = heroS[j].Durability;
                    row.ArmorType = heroS[j].ArmorType;
                    row.ColorType = heroS[j].ColorType;
                }

            }
            #region 查找已穿戴装备
            for (int l = 0; l < rowEquipList.Count; l++)
            {
                if (heroD[i].WID == rowEquipList[l].equipmentID)
                {
                    row.W = rowEquipList[l];
                }
                if (heroD[i].EID_1 == rowEquipList[l].equipmentID)
                {
                    row.E1 = rowEquipList[l];
                }
                if (heroD[i].EID_2 == rowEquipList[l].equipmentID)
                {
                    row.E2 = rowEquipList[l];
                }
            }
            #endregion
            finalDate.Add(row);
        }

        Debug.Log(JsonMapper.ToJson(finalDate).ToString());

        return finalDate;

    }
    public static List<RowHeroDate> ReadHeroDateAddEquip(List<RowHeroDate> data)
    {
        for (int i = 0; i < data.Count; i++)
        {
            data[i] = Add(data[i], data[i].W);
            data[i] = Add(data[i], data[i].E1);
            data[i] = Add(data[i], data[i].E2);
        }

        return data;
    }

    static RowHeroDate Add(RowHeroDate hero, RowEquipment equip)
    {
        if (equip == null)
        {
            return hero;
        }
        hero.LightningStrikes += equip.lightningStrikes;
        hero.Shelling += equip.shelling;
        hero.Filling += equip.filling;
        hero.AirDefense += equip.airDefense;
        hero.Aviation += equip.aviation;
        hero.Durability += equip.durability;

        return hero;
    }
}
