using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    //private AsyncOperation asy = null;

    public void Change()
    {
        Time.timeScale = 1;
        Prefabs.SceneSwitch(
            "Main", null           
            );
    }

    public void PauseClick() {
        PrefabsTwo.LoadUI("BattleUI/pause");

    }
}
