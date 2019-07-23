using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class ChuanwuListView : MonoBehaviour
{

    public GameObject View;
    List<RowHeroDate> RowDate;

    void Start()
    {
        Show();

    }

    public void Show()
    {
        View.transform.DetachChildren();
        RowDate = DynamicDataModel.ReadHeroData();
        ChuanWuDisPlay();
        Debug.Log(JsonMapper.ToJson(RowDate).ToString());
    }

    public void ChuanWuDisPlay()
    {
        for (int i = 0; i < RowDate.Count; i++)
        {

            GameObject go = Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/HeroInfo"));
            go.transform.SetParent(View.transform);
            go.GetComponent<HeroInfoView>().DisPlay(RowDate[i]);
            (go.transform as RectTransform).localScale = Vector3.one;
            (go.transform as RectTransform).localPosition=Vector3.zero;
        }


    }
}
