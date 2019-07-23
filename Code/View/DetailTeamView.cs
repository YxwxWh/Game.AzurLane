using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class DetailTeamView : MonoBehaviour
{
    private string key = "Team";
    List<RowHeroDate> RowDate;
    List<RowHeroDate> fHeroList;
    List<RowHeroDate> bHeroList;

    void Awake()
    {
        RowDate = DynamicDataModel.ReadHeroData();
    }

    public void DisPlay()
    {
        CleanHero();
        if (PlayerPrefs.GetString(key) != "")
        {
            //20190625 start
            //fHeroList = TeamModel.FowardHeroList(RowDate);
            //bHeroList = TeamModel.BackHeroList(RowDate);
            fHeroList = TeamModel.ReadTeamModel().fowardHeroList;
            bHeroList = TeamModel.ReadTeamModel().backHeroList;
            //20190625 end
            for (int i = 0; i < fHeroList.Count; i++)
            {
                AddForward(fHeroList[i], "Detail_Add_F" + (i + 1));
            }
            for (int i = 0; i < bHeroList.Count; i++)
            {
                AddForward(bHeroList[i], "Detail_Add_B" + (i + 1));
            }
        }
    }

    public void AddForward(RowHeroDate hero, string addPos)
    {
        Transform Team = transform.Find("Team");
        GameObject go = Instantiate(Resources.Load<GameObject>("Prefab/Detail_Competitivene"), Team);
        go.transform.position = Team.Find(addPos).position;
        go.GetComponent<DetailOneView>().DisPlay(hero);
        Team.Find(addPos).gameObject.SetActive(false);
    }

    public void CleanHero()
    {
        Transform Team = transform.Find("Team");
        for (int i = Team.childCount - 1; i >= 0; i--)
        {
            if (Team.GetChild(i).name.Substring(0, 10) == "Detail_Add")
            {
                Team.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                Destroy(Team.GetChild(i).gameObject);
            }
        }
    }
}
