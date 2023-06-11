using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZukanDirector : MonoBehaviour
{
    // ゲームオブジェクト
    GameObject[] tama = new GameObject[8];

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの取得
        tama[0] = GameObject.Find("c00");
        tama[1] = GameObject.Find("c01");
        tama[2] = GameObject.Find("c02");
        tama[3] = GameObject.Find("c03");
        tama[4] = GameObject.Find("c04");
        tama[5] = GameObject.Find("c05");
        tama[6] = GameObject.Find("c06");
        tama[7] = GameObject.Find("c07");

        // サムネイルの表示
        for (int i = 0; i < 8; i++)
        {
            if (dt.clearTamago[i] == 0)
            {
                tama[i].SetActive(false);
            }
            else
            {
                tama[i].SetActive(true);
            }
        }
    }
}
