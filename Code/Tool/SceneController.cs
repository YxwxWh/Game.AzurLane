using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;


public class SceneController : MonoBehaviour {
    private AsyncOperation asy = null;

    void Start () {
        DontDestroyOnLoad(gameObject);
        Debug.Log("加载了");
	}


    public void Click(string scene,UnityAction even) {
        StartCoroutine(zhuxiao(scene, even));
    }
    IEnumerator zhuxiao(string sceneName,UnityAction even)
    {
        asy = SceneManager.LoadSceneAsync(sceneName);
        asy.allowSceneActivation = false;
        //yield return asy;
        //Debug.Log("转换成功");

        while (true)
        {
            if (asy.progress >= 0.9f)
            {
                break;
            }
            yield return null;
        }

        asy.allowSceneActivation = true;

        if (even!=null) even();
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        
    }

}

