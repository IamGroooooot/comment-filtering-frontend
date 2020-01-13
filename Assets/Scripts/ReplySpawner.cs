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
    int count = 0;

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
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnReply("testtesttesttesttesttesttesttesttesttesttesttesttesttest");
        }*/
    }

    public void SpawnReply(string reply)
    {
        count++;
        
        justSpawned = Instantiate(replyTemplate,new Vector3(0,0,0), replyTemplate.transform.rotation, replyParent.transform);
        justSpawned.GetComponent<ReplyManager>().UpdateText(reply);

        justSpawned.GetComponent<RectTransform>().pivot = new Vector2(0.5f, 1f);
    }
}
