using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeaderView : MonoBehaviour
{
    public Text Shelling, LightningStrike, AirDefense, Aviation, Air, Consumption;

    public void DisPlay()
    {
        TeamData teamData = new TeamData();
        teamData = TeamModel.ReadTeamModel();
        Shelling.text = teamData.shelling.ToString();
        LightningStrike.text = teamData.lightningStrike.ToString();
        AirDefense.text = teamData.airDefense.ToString();
        Aviation.text = teamData.aviation.ToString();
        Air.text = teamData.air.ToString();
        Consumption.text = teamData.consumption.ToString();
    }
}
