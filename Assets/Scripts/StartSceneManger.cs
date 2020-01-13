using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManger : MonoBehaviour
{
    public void SignInBtnClicked()
    {
        SceneManager.LoadScene(1);
    }


}
