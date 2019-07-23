using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class FormationOneView : MonoBehaviour
{

    public Image Icon, TypeIcon;
    public Transform Stars;
    public Text Level;
    private FormationMenuController controller;
    private RowHeroDate heroInfo;

    private void Start()
    {
        controller = GameObject.Find("Canvas/FormationMain").GetComponent<FormationMenuController>();
    }

    public void DisPlay(RowHeroDate date)
    {
        heroInfo = date;
        string[] iconData = date.Icon.Split('#');
        SpriteAtlas iconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Formation_Card");
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

        Level.text = date.Level.ToString();
    }

    public void OnClick()
    {
        controller.EditFormation(heroInfo,0);
    }
}
