using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class EquipInfoView : MonoBehaviour
{
    public PackageController controller;

    public Text equipName;
    public Image icon;
    public Image color;
    public Image tier;
    public Text type;
    public Text damage;
    public Text attack;
    public Text price;
    public Text count;
    public Text rankValue;

    public void Display(RowEquipment data, PackageController controller) {
        this.controller = controller;
        //euipdata = data;
        equipName.text = data.name;
        string[] iconData = data.icon.Split('#');
        SpriteAtlas iconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/" + iconData[0]);
        icon.sprite = iconAtlas.GetSprite(iconData[1]);
        if (data.strLevel == 0)
        {
            rankValue.transform.parent.gameObject.SetActive(false);
            damage.text = data.atk.ToString();
        }
        else {
            rankValue.text = "+" + data.strLevel;
            damage.text = data.atk.ToString() + "+" + "<color=#EE0000>" + data.strLevel * 5 + "</color>";
        }
        //type.text = data.bt;
        attack.text = data.atk.ToString();
        price.text = data.price.ToString();
        count.text = data.count.ToString();

        switch (data.color)
        {
            case "gold":
                color.sprite = iconAtlas.GetSprite("gold_bg");
                break;
            case "colours":
                color.sprite = iconAtlas.GetSprite("colours_bg");
                break;
            case "purple":
                color.sprite = iconAtlas.GetSprite("purple_bg");
                break;
            case "blue":
                color.sprite = iconAtlas.GetSprite("blue_bg");
                break;
        }
        switch (data.tier)
        {
            case 1:
                tier.sprite = iconAtlas.GetSprite("1tier");
                break;
            case 2:
                tier.sprite = iconAtlas.GetSprite("2tier");
                break;
            case 3:
                tier.sprite = iconAtlas.GetSprite("3tier");
                break;
        }
       
    }

    public void Click()
    {
        Destroy(gameObject);
    }
    public void SellClick()
    {
        ButtonSound.ButtonClickPlay();
        controller.EquipSellClick(this);
    }
    public void StrClick()
    {
        ButtonSound.ButtonClickPlay();
        controller.RankUPClick(this);
        Destroy(gameObject);
    }
}
