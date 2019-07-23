using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class HeroInfoView : MonoBehaviour
{

    public Image AvatarIcon, Frame, TypeIcon, BgIcon;
    public Text Level, Name;
    public GameObject Stars;

    RowHeroDate _Date;



    public void DisPlay(RowHeroDate date)
    {
        _Date = date;

        Level.text = date.Level.ToString();
        Name.text = date.Name.ToString();

        string[] iconData = date.Icon.Split('#');
        SpriteAtlas iconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/" + iconData[0]);
        AvatarIcon.sprite = iconAtlas.GetSprite(iconData[1]);

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

        SpriteAtlas BgIconAtlas = Resources.Load<SpriteAtlas>("Img/SpriteAtlas/Detail_CardBgAtlas");
        switch (date.ColorType)
        {

            case "mix":
                BgIcon.sprite = BgIconAtlas.GetSprite("Mix_Bg");
                Frame.sprite = FrameIconAtlas.GetSprite("Mix_Frame");
                break;

            case "gold":
                BgIcon.sprite = BgIconAtlas.GetSprite("Gold_Bg");
                Frame.sprite = FrameIconAtlas.GetSprite("Gold_Frame");
                break;

            case "purple":
                BgIcon.sprite = BgIconAtlas.GetSprite("Purple_Bg");
                Frame.sprite = FrameIconAtlas.GetSprite("Purple_Frame");
                break;

            case "blue":
                BgIcon.sprite = BgIconAtlas.GetSprite("Blue_Bg");
                Frame.sprite = FrameIconAtlas.GetSprite("Blue_Frame");
                break;

            case "white":
                BgIcon.sprite = BgIconAtlas.GetSprite("Gray_Bg");
                Frame.sprite = FrameIconAtlas.GetSprite("Gray_Frame");
                break;
        }


        for (int i = 0; i < date.Stars; i++)
        {
            Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/StarIcon")).transform.SetParent(Stars.transform);
        }



    }

    public void OnClick()
    {
        GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/PlayerInfo"));
        go.transform.SetParent(GameObject.Find("UI/Canvas").transform);
        (go.transform as RectTransform).localScale = Vector3.one;
        (go.transform as RectTransform).localPosition = Vector3.zero;
        (go.transform as RectTransform).offsetMax = Vector2.zero;
        (go.transform as RectTransform).offsetMin = Vector2.zero;
        go.GetComponent<PlayerInfoView>().Str_DisPlay(_Date);
        Destroy(GameObject.Find("UI/Canvas/chuanwu"));
    }
}
