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

    public void OnConfirmBtnClicked()
    {
        // get input value
        Debug.Log("Sending Comment: " + inputField.text);
        myReply = inputField.text;
        // send input value
        StartCoroutine(FlaskUpload.instance.PostRequest(new Comment(1, myReply)));
        StartCoroutine(ChangeWhenRecieved());
    }

    public void OnCloseBtnClick()
    {
        this.transform.parent.gameObject.SetActive(false);
    }

    IEnumerator ChangeWhenRecieved()
    {
        inputField.text = "Loading 중";
        yield return new WaitUntil(()=> FlaskUpload.instance.isLoaded);

        if (FlaskUpload.instance.isToxic)
        {
            inputField.text = "악플입니다";
        }
        else
        {
            inputField.text = "악플이 아닙니다";
        }
       
    }
}
