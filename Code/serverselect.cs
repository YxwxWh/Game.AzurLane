using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class serverselect : MonoBehaviour {

    public int id;
	void Start () {
        GameObject go= transform.Find("Text").gameObject;
        go.GetComponent<Text>().text = "第" + id.ToString() + "服务器";
	}

    public void SeverClick() {
        GameObject go = GameObject.Find("Canvas/GameStart/start/sever_name");
        go.GetComponent<Text>().text = "第" + id.ToString() + "服务器";
        Destroy(GameObject.Find("Canvas/Select_sever"));
    }
   



}
