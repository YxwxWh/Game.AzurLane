using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public static class TeamModel
{

    /// <summary>
    /// 获取编队
    /// </summary>
    /// <returns></returns>
    public static TeamData ReadTeamModel()
    {
        TeamData teamData;
        string json = PlayerPrefs.GetString("Team");
        teamData = JsonMapper.ToObject<TeamData>(json);

        if (teamData == null)
        {
            teamData = new TeamData();
            List<RowHeroDate> flist = new List<RowHeroDate>();
            teamData.fowardHeroList = flist;
            List<RowHeroDate> blist = new List<RowHeroDate>();
            teamData.backHeroList = blist;
            teamData.shelling = 0;
            teamData.lightningStrike = 0;
            teamData.airDefense = 0;
            teamData.aviation = 0;
            teamData.air = 0;
            teamData.consumption = 0;
        }

        //Debug.Log("编队:" + json);
        return teamData;
    }

    /// <summary>
    /// 添加英雄到编队
    /// </summary>
    /// <param name="heroInfo">添加的英雄</param>
    public static void Add(RowHeroDate heroInfo)
    {
        TeamData teamData = ReadTeamModel();

        int armorType = heroInfo.ArmorType == "重型" ? 0 : 1;
        if (armorType == 1)
        {
            teamData.fowardHeroList.Add(heroInfo);
        }
        else
        {
            teamData.backHeroList.Add(heroInfo);
        }

        AddAttribute(heroInfo, ref teamData);

        PlayerPrefs.SetString("Team", JsonMapper.ToJson(teamData));
    }

    /// <summary>
    /// 替换编队中的英雄
    /// </summary>
    /// <param name="heroInfo">原有英雄</param>
    /// <param name="selectHeroInfo">替换英雄</param>
    public static void Change(RowHeroDate heroInfo, RowHeroDate selectHeroInfo)
    {
        TeamData teamData = ReadTeamModel();

        int armorType = heroInfo.ArmorType == "重型" ? 0 : 1;

        if (armorType == 1)
        {
            for (int i = 0; i < teamData.fowardHeroList.Count; i++)
            {
                if (teamData.fowardHeroList[i].PackageID == heroInfo.PackageID)
                {
                    teamData.fowardHeroList[i] = selectHeroInfo;
                    break;
                }
            }
        }else
        {
            for (int i = 0; i < teamData.backHeroList.Count; i++)
            {
                if (teamData.backHeroList[i].PackageID == heroInfo.PackageID)
                {
                    teamData.backHeroList[i] = selectHeroInfo;
                    break;
                }
            }
        }
        ChangeHero(heroInfo, selectHeroInfo, ref teamData);
        PlayerPrefs.SetString("Team", JsonMapper.ToJson(teamData));
    }

    /// <summary>
    /// 编队中英雄离队
    /// </summary>
    /// <param name="heroInfo">离队英雄</param>
    public static void Leave(RowHeroDate heroInfo)
    {
        TeamData teamData = ReadTeamModel();

        for (int i = 0; i < teamData.fowardHeroList.Count; i++)
        {
            if (teamData.fowardHeroList[i].PackageID == heroInfo.PackageID)
            {
                teamData.fowardHeroList.RemoveAt(i);
                break;
            }
        }

        for (int i = 0; i < teamData.backHeroList.Count; i++)
        {
            if (teamData.backHeroList[i].PackageID == heroInfo.PackageID)
            {
                teamData.backHeroList.RemoveAt(i);
                break;
            }
        }
        SubAttribute(heroInfo, ref teamData);
        PlayerPrefs.SetString("Team", JsonMapper.ToJson(teamData));
    }

    /// <summary>
    /// 根据PackageID验证英雄是否在队伍中
    /// </summary>
    /// <param name="heroInfo">验证英雄</param>
    /// <returns></returns>
    public static bool CheckIsOnTeamByPID(RowHeroDate heroInfo)
    {
        TeamData teamData;
        string json = PlayerPrefs.GetString("Team");
        teamData = JsonMapper.ToObject<TeamData>(json);

        if (teamData != null)
        {
            int armorType = heroInfo.ArmorType == "重型" ? 0 : 1;

            if (armorType == 1)
            {
                for (int i = 0; i < teamData.fowardHeroList.Count; i++)
                {
                    if (teamData.fowardHeroList[i].PackageID == heroInfo.PackageID)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < teamData.backHeroList.Count; i++)
                {
                    if (teamData.backHeroList[i].PackageID == heroInfo.PackageID)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    /// <summary>
    /// 根据HeroID验证上阵英雄是否在队伍中
    /// </summary>
    /// <param name="heroInfo">验证英雄</param>
    /// <returns></returns>
    public static bool CheckIsOnTeamByHeroId(RowHeroDate heroInfo)
    {
        TeamData teamData;
        string json = PlayerPrefs.GetString("Team");
        teamData = JsonMapper.ToObject<TeamData>(json);

        if (teamData != null)
        {
            int armorType = heroInfo.ArmorType == "重型" ? 0 : 1;

            if (armorType == 1)
            {
                for (int i = 0; i < teamData.fowardHeroList.Count; i++)
                {
                    if (teamData.fowardHeroList[i].HeroID == heroInfo.HeroID)
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < teamData.backHeroList.Count; i++)
                {
                    if (teamData.backHeroList[i].HeroID == heroInfo.HeroID)
                    {
                        return true;
                    }
                }
            }
        }

        return false;
    }

    /// <summary>
    /// 添加英雄后编队属性值增加
    /// </summary>
    /// <param name="heroInfo">英雄信息</param>
    /// <param name="teamData">编队信息</param>
    public static void AddAttribute(RowHeroDate heroInfo,ref TeamData teamData)
    {
        teamData.shelling += heroInfo.Shelling;
        teamData.lightningStrike += heroInfo.LightningStrikes;
        teamData.airDefense += heroInfo.AirDefense;
        teamData.aviation += heroInfo.Aviation;
        teamData.air = 0;
        teamData.consumption += heroInfo.Consumption;
    }

    /// <summary>
    /// 英雄离队后编队属性值减少
    /// </summary>
    /// <param name="heroInfo">英雄信息</param>
    /// <param name="teamData">编队信息</param>
    public static void SubAttribute(RowHeroDate heroInfo, ref TeamData teamData)
    {
        teamData.shelling -= heroInfo.Shelling;
        teamData.lightningStrike -= heroInfo.LightningStrikes;
        teamData.airDefense -= heroInfo.AirDefense;
        teamData.aviation -= heroInfo.Aviation;
        teamData.air = 0;
        teamData.consumption -= heroInfo.Consumption;
    }

    /// <summary>
    /// 替换英雄后属性值改变
    /// </summary>
    /// <param name="heroInfoB">替换前英雄</param>
    /// <param name="heroInfoA">替换后英雄</param>
    /// <param name="teamData">编队</param>
    public static void ChangeHero(RowHeroDate heroInfoB, RowHeroDate heroInfoA, ref TeamData teamData)
    {
        SubAttribute(heroInfoB, ref teamData);
        AddAttribute(heroInfoA, ref teamData);
    }
    
    /// <summary>
    /// 队伍上某个英雄发生改变
    /// </summary>
    /// <param name="heroInfo">改变的英雄</param>
    public static void ChangeHeroSelf(RowHeroDate heroInfo)
    {
        string json = PlayerPrefs.GetString("Team");
        TeamData teamData = JsonMapper.ToObject<TeamData>(json);

        if (teamData != null)
        {
            int armorType = heroInfo.ArmorType == "重型" ? 0 : 1;

            if (armorType == 1)
            {
                for (int i = 0; i < teamData.fowardHeroList.Count; i++)
                {
                    if (teamData.fowardHeroList[i].PackageID == heroInfo.PackageID)
                    {
                        ChangeHero(teamData.fowardHeroList[i], heroInfo, ref teamData);
                        teamData.fowardHeroList[i] = heroInfo;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < teamData.backHeroList.Count; i++)
                {
                    if (teamData.backHeroList[i].PackageID == heroInfo.PackageID)
                    {
                        ChangeHero(teamData.backHeroList[i], heroInfo, ref teamData);
                        teamData.backHeroList[i] = heroInfo;
                        break;
                    }
                }
            }
            PlayerPrefs.SetString("Team", JsonMapper.ToJson(teamData));
        }

    }

    /// <summary>
    /// 装备强化后队伍改变
    /// </summary>
    public static void EquioStrChange()
    {
        List<RowHeroDate> heroList = DynamicDataModel.ReadHeroData();
        for (int i = 0; i < heroList.Count; i++)
        {
            if (CheckIsOnTeamByPID(heroList[i]))
            {
                ChangeHeroSelf(heroList[i]);
            }
        }
    }

    public static bool IsAttack()
    {
        TeamData teamData = ReadTeamModel();
        if (teamData.fowardHeroList.Count == 0 || teamData.backHeroList.Count == 0)
        {
            return false;
        }else
        {
            return true;
        }
    }
}
