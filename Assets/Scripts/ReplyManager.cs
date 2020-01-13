using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplyManager : MonoBehaviour
{
    int max = 0;
    string newText="";
    public Comment comment;

    public void Awake()
    {
        comment = new Comment(0, "");
    }

    public void UpdateGlobalFilterRatio(float _ratio)
    {
        PlayerInfoManager.global_filterRatio = _ratio;
    }

    public void UpdateCommentFilterRatio(float _ratio)
    {
        comment.filterRatio = _ratio;
    }

    public void UpdateText(string myText)
    {
        newText = "";
        max = myText.Length;
        if (max > 66)
        {
            int pos = 0;
            for (int i=0; i < (max/66); i++)
            {
                newText += myText.Substring(pos, 66) + "\n";
                pos += 66;
            }
            newText += myText.Substring(pos);
            transform.GetChild(0).GetComponent<Text>().text = newText + "\n- " + PlayerInfoManager.id + " -";
            comment.reply = newText + "\n- " + PlayerInfoManager.id + " -";

        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text = myText + "\n- " + PlayerInfoManager.id + " -";
            comment.reply = myText + "\n- " + PlayerInfoManager.id + " -";
        }


    }
}
