using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarringMessageView : MonoBehaviour
{
    private float count;

    private void Start()
    {
        count = 0;
    }
    void Update ()
    {
        count += Time.deltaTime;
        if (count > 3)
        {
            Destroy(gameObject);
        }
	}
}
