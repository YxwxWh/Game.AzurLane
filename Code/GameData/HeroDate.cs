using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroDate
{
    //enum Type
    //{
    //    航母 = 0,
    //    战列舰 = 1,
    //    重巡 = 2,
    //    轻巡 = 3,
    //    驱逐 = 4,
    //}
    //enum ArmorType
    //{
    //    重型 = 0,
    //    轻型 = 1,

    //}

    public int HeroID, Shelling, LightningStrikes, AirDefense, Aviation, Consumption, Filling, Miss, Durability;
    public string Icon, Name, Type, ArmorType, ColorType ;


}
public class DynamicDate
{
    public int HeroID, Level, Stars,Exp, WID, EID_1, EID_2, PackageID;
    public DynamicDate(int ID,int level,int stars, int exp, int wid, int eid_1, int eid_2, int PID)
    {
        HeroID = ID;
        Level = level;
        Stars = stars;
        WID = wid;
        EID_1 = eid_1;
        EID_2 = eid_2;
        Exp = exp;
        PackageID = PID;
    }
    public DynamicDate()
    {
    }
}

public class RowHeroDate : HeroDate
{
    public int Level, Stars, Exp, PackageID;
    public RowEquipment W,E1,E2;
}
