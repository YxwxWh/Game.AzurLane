using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UILogin : MonoBehaviour
{
    public InputField Username;
    public InputField Password;
    public GameObject main;
    void Start()
    {
        main = GameObject.Find("Canvas/GameStart");
        
    }

    public void LoginClick()
    {
        if (Username.text == "" || Password.text == "")
        {
            Prefabs.Alert("登录信息不能为空",null);
            return;
        }

        //校验用户名和密码
        if (PlayerPrefs.GetString("Username") == Username.text && PlayerPrefs.GetString("Password") == Password.text)
        {
            Prefabs.Alert("登录成功",null);
            Destroy(gameObject);
            main.GetComponent<MainCode>().login = true;
        }
        else
        {
            Prefabs.Alert("登录失败",null);
        }
    }
    public void RegClick() {
        Prefabs.LoadUI("Prefab/zhuce");
        

    }
    public void DeleteClick() {
        Destroy(gameObject);

    }
}
