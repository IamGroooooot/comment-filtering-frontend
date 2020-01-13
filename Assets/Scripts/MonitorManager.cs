using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MonitorManager : MonoBehaviour
{
    InputField inputField;
    string myReply;

    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCloseBtnClick()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

}
