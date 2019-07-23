using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIRegister : MonoBehaviour
{
    public InputField Username;
    public InputField Password;
    public InputField RPassword;

    void Start()
    {

    }

    public void RegisterClick()
    {
        if(Username.text == "" || Password.text == "" || RPassword.text == "")
        {
            Prefabs.Alert("注册信息不能为空",null);
            return;
        }

        if (Password.text != RPassword.text)
        {
            Prefabs.Alert("两次密码不一致", null);
            return;
        }

        PlayerPrefs.SetString("Username", Username.text);
        PlayerPrefs.SetString("Password", Password.text);

        Prefabs.Alert("注册成功", null);

        //跨页面传递数据
        //UILogin script = transform.parent.Find("Login").GetComponent<UILogin>();
        //script.Username.text = Username.text;
        //script.Password.text = Password.text;
    }

    public void GoBackClick()
    {
        Destroy(gameObject);
    }
}
