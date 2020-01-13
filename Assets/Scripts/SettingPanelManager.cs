using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SettingPanelManager : MonoBehaviour
{
    public void CloseBtnClicked()
    {
        gameObject.SetActive(false);
    }

    public void OnLogoutBtnClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void UpdateFilterRatio()
    {
        float changedValue = transform.GetChild(2).GetComponent<Slider>().value;
        CommentUIManger.myComment.filterRatio = changedValue;
        Debug.Log("필터 강도 변경: " + changedValue);
        
    }


}
