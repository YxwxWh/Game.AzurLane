using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;

public class EquipListView : MonoBehaviour
{
    public PackageController controller;


    public void DisPlay_Choice(List<RowEquipment> data, PackageController controller, int num)
    {

        switch (num)
        {
            case 1:
                Display(data, controller);
                break;

            case 2:
                Display_wer(data, controller);
                break;
        }

    }
    void Display(List<RowEquipment> data, PackageController controller)
    {
        this.controller = controller;

        //Debug.Log("这啥"+JsonMapper.ToJson(data));

        transform.DeleteAllChild();

        for (int i = 0; i < data.Count; i++)
        {
            GameObject cell = PrefabsTwo.Load("Prefabs/equip", transform);
            cell.GetComponent<EquipCellView>().Display(data[i], controller);
        }

    }

    void Display_wer(List<RowEquipment> data, PackageController controller)
    {
        this.controller = controller;

        transform.DeleteAllChild();

        for (int i = 0; i < data.Count; i++)
        {
            if (controller.EquipPos=="W")
            {
                if (data[i].type==1)
                {
                    GameObject cell = PrefabsTwo.Load("Prefabs/Wearequip", transform);
                    cell.GetComponent<EquipCellView>().Display(data[i], controller);
                }
            }
            else
            {
                if (data[i].type == 0)
                {
                    GameObject cell = PrefabsTwo.Load("Prefabs/Wearequip", transform);
                    cell.GetComponent<EquipCellView>().Display(data[i], controller);
                }
            }
           
        }

    }
}
