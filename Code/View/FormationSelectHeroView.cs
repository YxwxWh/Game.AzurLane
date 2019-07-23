using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class FormationSelectHeroView : MonoBehaviour {

    public Image AvatarIcon,Frame,TypeIcon,BgIcon;
    public Text Level,Name;
    public GameObject Stars;
    private FormationSelectController controller;
    private RowHeroDate heroInfo;

    public void DisPlay(RowHeroDate date, FormationSelectController controller)
    {
        this.controller = controller;
        heroInfo = date;

        Level.text = date.Level.ToString();
        Name.text = date.Name.ToString();

        string[] iconData = date.Icon.Split('#');
        SpriteAtlas iconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/" + iconData[0]);
        AvatarIcon.sprite = iconAtlas.GetSprite(iconData[1]);

        SpriteAtlas FrameAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/FrameAtlas");
        switch (date.Type)
        {
            case "航母":
                TypeIcon.sprite = FrameAtlas.GetSprite("hangmu");
                break;
            case "重巡":
                TypeIcon.sprite = FrameAtlas.GetSprite("zhongxun");
                break;
            case "轻巡":
                TypeIcon.sprite = FrameAtlas.GetSprite("qingxun");
                break;
            case "战列舰":
                TypeIcon.sprite = FrameAtlas.GetSprite("zhanlie");
                break;
            case "驱逐":
                TypeIcon.sprite = FrameAtlas.GetSprite("quzhu");
                break;
        }

        SpriteAtlas BgIconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Detail_CardBgAtlas");
        switch (date.ColorType)
        {
            
            case "mix":
                Frame.sprite = FrameAtlas.GetSprite("Mix_Frame");
                BgIcon.sprite = BgIconAtlas.GetSprite("Mix_Bg");
                break;

            case "gold":
                Frame.sprite = FrameAtlas.GetSprite("Gold_Frame");
                BgIcon.sprite = BgIconAtlas.GetSprite("Gold_Bg");
                break;

            case "purple":
                Frame.sprite = FrameAtlas.GetSprite("Purple_Frame");
                BgIcon.sprite = BgIconAtlas.GetSprite("Purple_Bg");
                break;

            case "blue":
                Frame.sprite = FrameAtlas.GetSprite("Blue_Frame");
                BgIcon.sprite = BgIconAtlas.GetSprite("Blue_Bg");
                break;

            case "white":
                Frame.sprite = FrameAtlas.GetSprite("Gray_Frame");
                BgIcon.sprite = BgIconAtlas.GetSprite("Gray_Bg");
                break;
        }


        for (int i = 0; i < date.Stars; i++)
        {
            Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/StarIcon")).transform.SetParent(Stars.transform);
        }
    }

    public void Onclick()
    {
        bool isOnTeam;
        if (controller.pos != 3)
        {
            isOnTeam = TeamModel.CheckIsOnTeamByHeroId(heroInfo);
        }else
        {
            isOnTeam = TeamModel.CheckIsOnTeamByPID(heroInfo);
        }
        if (isOnTeam)
        {
            //Instantiate(Resources.Load<GameObject>("Prefab/WarringMessage"),GameObject.Find("Canvas").transform);
            PrefabsTwo.Alert("该英雄在编队中,无法选中", null);
            return;
        }
        controller.selectHeroInfo = heroInfo;
        controller.SelectNum.text = "1";
        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if(transform.parent.GetChild(i).name.Substring(0,9) == "LevelTeam")
            {
                continue;
            }
            transform.parent.GetChild(i).Find("Selected").gameObject.SetActive(false);
        }
        transform.Find("Selected").gameObject.SetActive(true);
    }
}
