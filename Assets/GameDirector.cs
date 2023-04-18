using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    // 変数もろもろ
    public static int cursorPos;                // カーソル位置

    // ゲームオブジェクト
    GameObject[] cursor = new GameObject[5];

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの取得
        cursor[0] = GameObject.Find("cursor0");
        cursor[1] = GameObject.Find("cursor1");
        cursor[2] = GameObject.Find("cursor2");
        cursor[3] = GameObject.Find("cursor3");
        cursor[4] = GameObject.Find("cursor4");

        // カーソル表示の初期化
        cursorPos = 0;
        for(int i=1; i<5; i++)
        {
            cursor[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<5; i++)
        {
            if(i == cursorPos)
            {
                cursor[i].SetActive(true);
            }
            else
            {
                cursor[i].SetActive(false);
            }
        }
    }
}
