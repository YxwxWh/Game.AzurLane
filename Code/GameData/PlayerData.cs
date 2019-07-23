using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip
{
    public int equipmentID;
    public int count;
    public int strLevel;
}

public class PlayerData
{
    public int oil;
    public int diamond;
    public int gold;
    public List<Equip> equips;
}
