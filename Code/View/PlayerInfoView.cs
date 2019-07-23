using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

public class PlayerInfoView : MonoBehaviour
{
    RowHeroDate Date;

    public Image Info_PlayerLevel_Bg, Info_Player_Bg, 
                 Str_PlayerLevel_Bg, Str_Player_Bg, Str_Type;


    public Text Name, Durability, Shelling, LightningStrikes, AirDefense, Aviation, Consumption,
                Filling, Miss, ArmorType,Level,
                Str_Name;

    public void Info()
    {
        ButtonSound.ButtonClickPlay();
        Info_DisPlay(Date);
    }

    public void Info_DisPlay(RowHeroDate date)
    {
        
        SpriteAtlas PlayerLevel_BgSA = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/PlayerInfo_Bg");
        Info_PlayerLevel_Bg.sprite = PlayerLevel_BgSA.GetSprite("PlayInfo_" + date.ColorType + "_Bg");

        string[] BgData = date.Icon.Split('#');
        SpriteAtlas Player_BgSA = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Hero_Bg");
        Info_Player_Bg.sprite = Player_BgSA.GetSprite(BgData[1]);
        Info_Player_Bg.SetNativeSize();


        #region 1
        SpriteAtlas TypeSpriteAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/FrameAtlas");
       
        #endregion

        Name.text = date.Name;
        Level.text = "Level:" + date.Level.ToString();

        Durability.text = date.Durability.ToString();
        Shelling.text = date.Shelling.ToString();
        LightningStrikes.text = date.LightningStrikes.ToString();
        AirDefense.text = date.AirDefense.ToString();
        Aviation.text = date.Aviation.ToString();
        Consumption.text = date.Consumption.ToString();
        Filling.text = date.Filling.ToString();
        Miss.text = date.Miss.ToString();
        ArmorType.text = date.ArmorType.ToString();


    }

    public void Str_DisPlay(RowHeroDate date)
    {
        Date = date;

        SpriteAtlas PlayerLevel_BgSA = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/PlayerInfo_Bg");
        Str_PlayerLevel_Bg.sprite = PlayerLevel_BgSA.GetSprite("PlayInfo_" + date.ColorType + "_Bg");

        string[] BgData = date.Icon.Split('#');
        SpriteAtlas Player_BgSA = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Hero_Bg");
        Str_Player_Bg.sprite = Player_BgSA.GetSprite(BgData[1]);
        Str_Player_Bg.SetNativeSize();


        #region 1
        SpriteAtlas TypeSpriteAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/FrameAtlas");

        switch (date.Type)
        {
            case "航母":
                Str_Type.sprite = TypeSpriteAtlas.GetSprite("CV");
                break;

            case "战列舰":
                Str_Type.sprite = TypeSpriteAtlas.GetSprite("BB");
                break;

            case "重巡":
                Str_Type.sprite = TypeSpriteAtlas.GetSprite("CA");
                break;

            case "轻巡":
                Str_Type.sprite = TypeSpriteAtlas.GetSprite("CL");
                break;

            case "驱逐":
                Str_Type.sprite = TypeSpriteAtlas.GetSprite("DD");
                break;
        }
        #endregion

        Str_Name.text = date.Name;

    }
    public void Equip_DisPlay()
    {
        ButtonSound.ButtonClickPlay();
        this.GetComponent<PlayerInfoEquipView>().DisPlay(Date);
    }

    public void OpenPackage(string pos)
    {
        GameObject go = PrefabsTwo.LoadUI("Prefabs/Packege");
        go.GetComponent<PackageController>().Choice = 2;

        go.GetComponent<PackageController>().EquipPos = pos;
        go.GetComponent<PackageController>().EquipHero = Date;

        go.GetComponent<PackageController>().ShowPackage();

        
        Destroy(gameObject);


    }

    public void BackToMain()
    {
        ButtonSound.ButtonClickPlay();
        PrefabsTwo.LoadUI("Prefabs/chuanwu");
        Destroy(gameObject);
    }
}
