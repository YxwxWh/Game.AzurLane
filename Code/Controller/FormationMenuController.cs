using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormationMenuController : MonoBehaviour
{

    public  GameObject DetailMain;
    public GameObject FormationBottom;
    public GameObject DetailBottom;
    public RowHeroDate heroInfo;
    public int type=0, pos;

    void Start () {
        DisPlay();
    }
	
    public void DisPlay()
    {
        transform.Find("FormationMain").GetComponent<FormationTeamView>().DisPlay();
        if (type == 1)
        {
            DetailMain.SetActive(true);
            transform.Find("DetailMain").GetComponent<DetailTeamView>().DisPlay();
        }
        transform.Find("Header").GetComponent<HeaderView>().DisPlay();
    }

    public void BackToMain()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("MainMenu");
        Destroy(gameObject);
    }
    public void Change()
    {
        ButtonSound.ButtonClickPlay();
        DetailMain.SetActive(!DetailMain.activeSelf);
        FormationBottom.SetActive(!FormationBottom.activeSelf);
        DetailBottom.SetActive(!DetailBottom.activeSelf);
        type = 1 - type;
        DisPlay();
    }
    public void AddFormation(int pos,int type)
    {
        this.pos = pos;
        this.type = type;
        GameObject go = PrefabsTwo.LoadUI("Prefabs/FormationSelect");
        go.GetComponent<FormationSelectController>().pos = pos;
        go.GetComponent<FormationSelectController>().type = type;
        Destroy(gameObject);
    }

    public void EditFormation(RowHeroDate heroInfo, int type)
    {
        this.type = type;
        GameObject go = PrefabsTwo.LoadUI("Prefabs/FormationSelect");
        go.GetComponent<FormationSelectController>().heroInfo = heroInfo;
        go.GetComponent<FormationSelectController>().type = type;
        Destroy(gameObject);
    }

    public void ToPlayInfo(RowHeroDate heroInfo)
    {
        GameObject go = PrefabsTwo.LoadUI("Prefabs/PlayerInfo");
        go.GetComponent<PlayerInfoView>().Str_DisPlay(heroInfo);

    }
}
