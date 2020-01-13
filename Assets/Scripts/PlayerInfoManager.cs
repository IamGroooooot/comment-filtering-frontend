using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfoManager : MonoBehaviour
{
    public static string reg_id;
    public static string reg_pw;
    public static float global_filterRatio=0;

    // 비번이 그냥 노출됨. ( 주의 )
    // 프로토타이핑이라 걍 대충 만듦
    public static string id;
    public static string pw;
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
