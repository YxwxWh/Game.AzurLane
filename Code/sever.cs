using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sever : MonoBehaviour {
    public Transform father;
	
	void Start () {
        for (int i = 1; i <=12; i++)
        {
            GameObject go = Prefabs.Load("Prefab/sever", father);
            go.GetComponent<serverselect>().id = i;
            
      }
	}

    public void BackClick() {
        Destroy(gameObject);
    }
}
