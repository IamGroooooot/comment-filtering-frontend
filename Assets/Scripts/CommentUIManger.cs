using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CommentUIManger : MonoBehaviour
{
    GameObject settingButton;
    InputField inputField;
    bool wasFocused = false;
    public static Comment myComment;
    Text statusText;
    GameObject hideGameObject;

    void Awake()
    {
        myComment = new Comment(0, "");
        wasFocused = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        settingButton = GameObject.Find("Button_settings");
        inputField = GameObject.Find("Comment_Field").GetComponent<InputField>();
        statusText = GameObject.Find("Status_Text").GetComponent<Text>();
        hideGameObject = GameObject.Find("Hide");
        hideGameObject.SetActive(false);
    }

    public void UpdateComment()
    {
        myComment.reply = inputField.text;
        Debug.Log("입력한 문자열 수정: " + myComment.reply);
    }

    // Update is called once per frame
    void Update()
    {
        if (wasFocused && (Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter)))
        {
            UpdateComment();
            OnConfirmBtnClicked();
        }
        wasFocused = inputField.isFocused;
    }

    public void OnSettingBtnClicked()
    {
        transform.GetChild(6).gameObject.SetActive(!transform.GetChild(6).gameObject.activeSelf);
    }

    public void OnConfirmBtnClicked()
    {
        // get input value
        Debug.Log("Sending Comment: " + inputField.text);
        myComment.reply = inputField.text;

        // send input value
        StartCoroutine(FlaskUpload.instance.PostRequest(myComment));
        StartCoroutine(ChangeWhenRecieved());
        ReplySpawner.instance.SpawnReply(inputField.text);

    }

    IEnumerator ChangeWhenRecieved()
    {
        hideGameObject.SetActive(true);
        while (!FlaskUpload.instance.isLoaded)
        {
            statusText.text = "Filtering.";
            yield return new WaitForSeconds(0.5f);
            statusText.text = "Filtering..";
            yield return new WaitForSeconds(0.5f);
            statusText.text = "Filtering...";
            yield return new WaitForSeconds(0.5f);
        }

        // 응답이 올 때까지 기다림
        yield return new WaitUntil(() => FlaskUpload.instance.isLoaded);

        hideGameObject.SetActive(false);

        if (FlaskUpload.instance.isToxic)
        {
            statusText.text = "Toxic Comment. Swearing Power: " + (FlaskUpload.instance.swearingPower*100/3.6f).ToString("F2")+"%";
            statusText.color = Color.red;
            inputField.text = "";
        }
        else
        {
            statusText.text = "Non-Toxic Comment. Swearing Power: " + (FlaskUpload.instance.swearingPower * 100 / 3.6f).ToString("F2")+"%";
            statusText.color = Color.blue;
            inputField.text = "";
        }

        ReplySpawner.instance.UpdateCommentInstanceRatio(FlaskUpload.instance.swearingPower);
        ReplySpawner.instance.HideAndReviveReplyHigherThen();
    }
}
