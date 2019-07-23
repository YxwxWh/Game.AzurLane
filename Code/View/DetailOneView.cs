using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class DetailOneView : MonoBehaviour
{

    public Image Frame, Icon, TypeIcon, Bg;
    public Transform Stars;
    public Text Level, Name, Durable, Consumption;
    private FormationMenuController controller;
    private RowHeroDate heroInfo;

    private void Start()
    {
        controller = GameObject.Find("Canvas/FormationMain").GetComponent<FormationMenuController>();
    }

    public void DisPlay(RowHeroDate date)
    {
        heroInfo = date;

        SpriteAtlas FrameAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/FrameAtlas");
        SpriteAtlas BgAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Detail_CardBgAtlas");
        switch (date.ColorType)
        {
            case "gray":
                Frame.sprite = FrameAtlas.GetSprite("Gray_Frame");
                Bg.sprite = BgAtlas.GetSprite("Gray_Bg");
                break;
            case "blue":
                Frame.sprite = FrameAtlas.GetSprite("Blue_Frame");
                Bg.sprite = BgAtlas.GetSprite("Blue_Bg");
                break;
            case "purple":
                Frame.sprite = FrameAtlas.GetSprite("Purple_Frame");
                Bg.sprite = BgAtlas.GetSprite("Purple_Bg");
                break;
            case "gold":
                Frame.sprite = FrameAtlas.GetSprite("Gold_Frame");
                Bg.sprite = BgAtlas.GetSprite("Gold_Bg");
                break;
            case "mix":
                Frame.sprite = FrameAtlas.GetSprite("Mix_Frame");
                Bg.sprite = BgAtlas.GetSprite("Mix_Bg");
                break;
        }

        string[] iconData = date.Icon.Split('#');
        SpriteAtlas iconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Detail_CardAtlas");
        Icon.sprite = iconAtlas.GetSprite(iconData[1]);

        SpriteAtlas FrameIconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/FrameAtlas");
        switch (date.Type)
        {
            case "航母":
                TypeIcon.sprite = FrameIconAtlas.GetSprite("hangmu");
                break;
            case "重巡":
                TypeIcon.sprite = FrameIconAtlas.GetSprite("zhongxun");
                break;
            case "轻巡":
                TypeIcon.sprite = FrameIconAtlas.GetSprite("qingxun");
                break;
            case "战列舰":
                TypeIcon.sprite = FrameIconAtlas.GetSprite("zhanlie");
                break;
            case "驱逐":
                TypeIcon.sprite = FrameIconAtlas.GetSprite("quzhu");
                break;
        }

        for (int i = 0; i < date.Stars; i++)
        {
            Instantiate<GameObject>(Resources.Load<GameObject>("Prefab/Formation_Star"), Stars);
        }

        Level.text = "LV." + date.Level;
        Name.text = date.Name;
        Durable.text = date.Durability.ToString();
        Consumption.text = date.Consumption.ToString();
    }

    public void OnClick()
    {
        controller.ToPlayInfo(heroInfo);
    }
}
