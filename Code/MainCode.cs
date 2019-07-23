using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainCode : MonoBehaviour
{
    public bool login;

    void Start()
    {
        login = false;
    }


    public void SelectServer()
    {
        Prefabs.LoadUI("Prefab/Select_sever");
    }

    public void GameStartClick()
    {
        if (login)
        {
            GameObject go = GameObject.Find("Canvas/GameStart/start/sever_name");
            if (go.GetComponent<Text>().text.Length > 2)
            {
                Destroy(gameObject);
                //Prefabs.LoadUI("Prefabs/MainMenu");
                gameObject.transform.parent.Find("MainMenu").gameObject.SetActive(true);
                return;
            }
            else
            {
                SelectServer();
            }
        }
        else
        {
            Prefabs.LoadUI("Prefab/login");
        }

    }

    public void SetingButton()
    {
        GameObject main = GameObject.Find("Canvas/Main/mainmenu");
        GameObject set = GameObject.Find("Canvas/Main/seting");

        main.SetActive(!main.activeSelf);
        set.SetActive(!set.activeSelf);
    }

    public void DeleteUserData() {
        PlayerPrefs.DeleteAll();

    }

}
