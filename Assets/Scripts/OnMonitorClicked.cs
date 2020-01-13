using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMonitorClicked : MonoBehaviour
{
    GameObject compScreenPanel;
    void Start()
    {
        compScreenPanel = GameObject.FindGameObjectWithTag("Comp");
        //compScreenPanel.SetActive(false);
    }

    void OnMouseDown()
    {
        compScreenPanel.SetActive(true);
        Debug.Log("모니터 클릭");
    }
}
