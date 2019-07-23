using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class PlayerInfoEquipView : MonoBehaviour {
    public Image W_Bg, W_Frame, W_Icon;
    public Text W_Name, W_Type, W_StrLevel, W_Tier;

    public Image E1_Bg, E1_Frame, E1_Icon;
    public Text E1_Name, E1_Type, E1_StrLevel, E1_Tier;

    public Image E2_Bg, E2_Frame, E2_Icon;
    public Text E2_Name, E2_Type, E2_StrLevel, E2_Tier;
    public void DisPlay(RowHeroDate date)
    {
        Show(date.W,W_Bg,W_Frame,W_Name, W_Icon, W_Type, W_StrLevel, W_Tier);
        Show(date.E1, E1_Bg, E1_Frame, E1_Name, E1_Icon, E1_Type, E1_StrLevel, E1_Tier);
        Show(date.E2, E2_Bg, E2_Frame, E2_Name, E2_Icon, E2_Type, E2_StrLevel, E2_Tier);
    }

    void Show(RowEquipment e,Image bg,Image frame,Text name,Image icon,Text type,Text strLevel, Text tier)
    {
        if (e==null)
        {
            return;
        }      

        SpriteAtlas EquipLevel_Bg = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Detail_CardBgAtlas");

        SpriteAtlas EquipLevel_Frame = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/EquipFrameAtlas");

        SpriteAtlas EquipIcon_Bg = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Equip");
        string[] EquipIcon = e.icon.Split('#');

        name.text = e.name;
        icon.sprite = EquipIcon_Bg.GetSprite(EquipIcon[1]);
        icon.SetNativeSize();

        switch (e.bt)
        {
            case BulletType.AP:
                type.text = "<color='#A7E975FF'>穿甲弹</color>";
                break;
            case BulletType.HE:
                type.text = "<color='#A7E975FF'>高爆弹</color>";
                break;
            case BulletType.NO:
                type.text = "<color='#A7E975FF'>普通弹</color>";
                break;
            case BulletType.EQ:
                type.text = "<color='#A7E975FF'>设备</color>";
                break;
        }

        switch (e.color)
        {
            case "gray":
                bg.sprite = EquipLevel_Bg.GetSprite("Gray_Bg");                
                frame.sprite = EquipLevel_Frame.GetSprite("Equip_Gray_Frame");   
                break;

            case "blue":
                W_Bg.sprite = EquipLevel_Bg.GetSprite("Blue_Bg");
                frame.sprite = EquipLevel_Frame.GetSprite("Equip_Blue_Frame");
                break;

            case "purple":
                bg.sprite = EquipLevel_Bg.GetSprite("Purple_Bg");
                frame.sprite = EquipLevel_Frame.GetSprite("Equip_Purple_Frame");
                break;

            case "gold":
                bg.sprite = EquipLevel_Bg.GetSprite("Gold_Bg");
                frame.sprite = EquipLevel_Frame.GetSprite("Equip_Gold_Frame");
                break;

            case "mix":
                bg.sprite = EquipLevel_Bg.GetSprite("Mix_Bg");
                frame.sprite = EquipLevel_Frame.GetSprite("Equip_Mix_Frame");
                break;
        }

        strLevel.text = "<color='#A7E975FF'>" + e.strLevel + "</color>";
        tier.text = "T" + e.tier;

    }

    public void ButtonClick()
    {
        ButtonSound.ButtonClickPlay();
    }
}
