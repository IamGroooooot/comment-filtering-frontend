using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RegisterManager : MonoBehaviour
{
    public void SignUpBtnClicked()
    {
        PlayerInfoManager.reg_id = GameObject.Find("InputField_ID").GetComponent<InputField>().text;
        PlayerInfoManager.reg_pw = GameObject.Find("InputField_PW").GetComponent<InputField>().text;

        if (PlayerInfoManager.reg_id.Length > 0 && PlayerInfoManager.reg_pw.Length > 0)
            SceneManager.LoadScene(0);
        else
        {
            
        }
    }
}
