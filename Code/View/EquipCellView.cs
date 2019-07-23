using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class EquipCellView : MonoBehaviour {
    public Transform father;
    public Image icon;
    public Image color;
    public Text equipName;
    public Text count;
    public Image rankImg;
    public Text rank;

    public PackageController controller;
    private RowEquipment data;

    public void Display(RowEquipment data, PackageController controller)
    {
        this.controller = controller;
        this.data = data;
        string[] iconData = data.icon.Split('#');
        SpriteAtlas iconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/" + iconData[0]);
        icon.sprite = iconAtlas.GetSprite(iconData[1]);
        if (data.strLevel== 0)
        {
            rankImg.gameObject.SetActive(false);
            rank.gameObject.SetActive(false);
        }
        else
        {
            rank.text="+"+ data.strLevel;
        }

        switch (data.color)
        {
            case "gold":
                color.sprite = iconAtlas.GetSprite("gold");
                break;
            case "colours":
                color.sprite = iconAtlas.GetSprite("colours");
                break;
            case "purple":
                color.sprite = iconAtlas.GetSprite("purple");
                break;
            case "blue":
                color.sprite = iconAtlas.GetSprite("blue");
                break;
        }
        count.text = data.count.ToString();
        equipName.text = data.name;
    }

    public void Click()
    {
        controller.EquipCellClick(data);
    }

    public void WearEquip()
    {

        controller.WearEquip(data);

    }

    
}
