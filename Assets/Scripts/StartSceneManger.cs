using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneManger : MonoBehaviour
{

    public void SignInBtnClicked()
    {
        PlayerInfoManager.id = GameObject.Find("InputField_ID").GetComponent<InputField>().text;
        PlayerInfoManager.pw = GameObject.Find("InputField_PW").GetComponent<InputField>().text;

        if (PlayerInfoManager.id.Length > 0 
            && PlayerInfoManager.pw.Length > 0 
            && PlayerInfoManager.reg_id == GameObject.Find("InputField_ID").GetComponent<InputField>().text 
            && PlayerInfoManager.reg_pw == GameObject.Find("InputField_PW").GetComponent<InputField>().text)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            GameObject.Find("signin_status").GetComponent<Text>().text = "Please check your id or password.";
        }
    }

    public void RegisterBtnClicked()
    {
        SceneManager.LoadScene(2);
    }
}
