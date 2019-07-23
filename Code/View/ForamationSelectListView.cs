using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ForamationSelectListView : MonoBehaviour
{
    public GameObject View;
    List<RowHeroDate> RowDate;
    public int type;//0:重型前排,1:轻型后排
    private FormationSelectController controller;

    void Start () {
        RowDate = DynamicDataModel.ReadHeroData();
        RowDate = StaticDataModel.ReadHeroDateAddEquip(RowDate);
    }

    public void DisPlay(FormationSelectController controller,int pos, RowHeroDate heroInfo)
    {
        string armorType;
        if (heroInfo == null)
        {
            //armorType = pos == 0 ? "重型" : "轻型";
            if (pos == 0)
            {
                armorType = "重型";
            }else if(pos == 1)
            {
                armorType = "轻型";
            }else
            {
                armorType = "";
            }
        }else
        {
            armorType = heroInfo.ArmorType;
        }
        this.controller = controller;
        for (int i = -1; i < RowDate.Count; i++)
        {
            GameObject go;
            if (i == -1)
            {
                if(heroInfo != null)
                {
                    go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefab/LevelTeam"), View.transform);
                }
                else
                {
                    continue;
                }
            }
            else
            {
                if (armorType != "" && RowDate[i].ArmorType != armorType) 
                {
                    continue;
                }
                go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefab/FormationSelect_HeroInfo"), View.transform);
                go.GetComponent<FormationSelectHeroView>().DisPlay(RowDate[i],controller);
            }
            (go.transform as RectTransform).localScale = Vector3.one;
            (go.transform as RectTransform).localPosition = Vector3.zero;
        }
    }
}
