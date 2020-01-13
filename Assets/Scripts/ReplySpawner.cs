using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplySpawner : MonoBehaviour
{
    public static ReplySpawner instance;
    public GameObject replyTemplate;
    RectTransform SpawnPos;
    GameObject replyParent;
    public LayerMask cantSee;
    GameObject justSpawned;

    void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        replyParent = GameObject.Find("replies");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnReply(string reply)
    {
        justSpawned = Instantiate(replyTemplate,new Vector3(0,0,0), replyTemplate.transform.rotation, replyParent.transform);
        justSpawned.GetComponent<ReplyManager>().UpdateText(reply);
        justSpawned.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
    }

    public void HideAndReviveReplyHigherThen()
    {
        Debug.Log("필터링 재시도, 필터값: " + PlayerInfoManager.global_filterRatio);

        float ratio = PlayerInfoManager.global_filterRatio;
        Transform child;
        for(int a=0; a< replyParent.transform.childCount; a++)
        {
            child = replyParent.transform.GetChild(a);
            if (child.GetComponent<ReplyManager>().comment.filterRatio > ratio)
            {
                //Debug.Log(child.GetComponent<ReplyManager>().comment.filterRatio);
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }
        }

        Debug.Log("필터링 끝");
    }

    public void UpdateCommentInstanceRatio(float ratio)
    {
        justSpawned.GetComponent<ReplyManager>().UpdateCommentFilterRatio(ratio);
    }
}
