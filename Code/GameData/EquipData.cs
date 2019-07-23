using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicEquipmentDate
{
    public int equipmentID,cout,strLevel;
}

public class Equipment  //静态数据
{
    public int equipmentID;
    public string icon;
    public string name;
    public int type;
    public string color;

    public int shelling;
    public int lightningStrikes;
    public int airDefense;
    public int aviation;
    public int filling;
    public int miss;
    public int durability;

    public double atk;
    public int shotDeg;
    public int shotNumber;
    public double countTime;
    public int range;
    public BulletType bt;
    public int speed;
    public int pierce;
    public int price;

    public int tier;
}

public class RowEquipment: Equipment
{
    public int count, strLevel;
}