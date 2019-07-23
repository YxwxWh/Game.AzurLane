using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IsClone : MonoBehaviour {
    public static bool isClone;
    public GameObject obj;
    private GameObject cloneObj;
    void Awake()
    {
        if (!isClone)
        {
            GameObject go = Resources.Load<GameObject>("boot");
            cloneObj = Instantiate(go);
            isClone = true;
        }
        else {
            Prefabs.LoadGameObject("MainMenu");
        }
        
        DontDestroyOnLoad(cloneObj);
    }

    
}
