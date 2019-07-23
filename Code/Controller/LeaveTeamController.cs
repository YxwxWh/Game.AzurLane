using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTeamController : MonoBehaviour
{
    private FormationSelectController controller;
    
    void Start () {
        controller = GameObject.Find("Canvas/FormationSelect").GetComponent<FormationSelectController>();
    }

    public void Leave()
    {
        controller.LeaveTeam();
    }
}
