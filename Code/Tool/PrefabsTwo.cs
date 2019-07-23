using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public static class PrefabsTwo
{
    public static GameObject LoadUI(string prefabPath)
    {
        //加载登陆页
        GameObject prefab = Resources.Load<GameObject>(prefabPath);
        //创建界面
        GameObject page = GameObject.Instantiate<GameObject>(prefab);
        //防止出现克隆
        page.name = prefab.name;
        //找到画布
        Transform canvas = GameObject.Find("UI/Canvas").transform;

        //设置父物体
        page.transform.SetParent(canvas);
        //页面初始化位置等
        page.transform.localPosition = Vector3.zero;
        page.transform.localRotation = Quaternion.identity;
        page.transform.localScale = Vector3.one;

        RectTransform rtf = page.transform as RectTransform;
        //左边距和上边距归零
        rtf.offsetMin = Vector2.zero;
        //右边距和下边距归零
        rtf.offsetMax = Vector2.zero;

        //把页面设置为最后一个物体
        rtf.SetAsLastSibling();

        return page;
    }

    public static GameObject Load(string path, Transform father)
    {
        //创建GO
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject go = GameObject.Instantiate<GameObject>(prefab);
        go.name = prefab.name;
        //将GO设置父物体
        go.transform.SetParent(father);
        go.transform.localPosition = Vector3.zero;
        go.transform.localRotation = Quaternion.identity;
        go.transform.localScale = Vector3.one;

        return go;
    }

    public static void Alert(string message, UnityAction okCallback)
    {
        GameObject page = LoadUI("Prefabs/inform");
        //page.transform.Find("infotext").GetComponent<Text>().text = message;
        page.transform.Find("infotext").GetComponent<TextMeshProUGUI>().text = message;

        //使用Lambda表达式，先销毁自身对象，再调用传递过来的回调函数
        page.transform.Find("exit").GetComponent<Button>().onClick.AddListener(() =>
        {
            ButtonSound.ButtonClickPlay();
            GameObject.Destroy(page);

            if (okCallback != null)
            {
                okCallback();
            }
        });

        page.transform.Find("confirm").GetComponent<Button>().onClick.AddListener(() => 
        {
            ButtonSound.ButtonClickPlay();
            GameObject.Destroy(page);

            if (okCallback != null)
            {
                okCallback();
            }
        });

        /*
        Lambda表达式

        (aa, bb) =>
        {
            int i = 0;
        }
        */
    }


    public static GameObject LoadHPpoint(string prefabPath)
    {
        //加载登陆页
        GameObject prefab = Resources.Load<GameObject>(prefabPath);
        //创建界面
        GameObject page = GameObject.Instantiate<GameObject>(prefab);
        //防止出现克隆
        page.name = prefab.name;
        //找到画布
        Transform canvas = GameObject.Find("UI/HPCanvas").transform;

        //设置父物体
        page.transform.SetParent(canvas);
        //页面初始化位置等
        page.transform.localPosition = new Vector3(3000, 0 ,0);
        //page.transform.localRotation = Quaternion.identity;
        page.transform.localScale = Vector3.one;       
        return page;
    }

}
