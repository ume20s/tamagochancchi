using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dt : MonoBehaviour
{
    // クリアたまごちゃん記録用配列
    static public int[] clearTamago = new int[8];

    // クリアたまごちゃん保存キー
    static public readonly string[] SAVE_KEY = {
        "KuriTama0",
        "KuriTama1",
        "KuriTama2",
        "KuriTama3",
        "KuriTama4",
        "KuriTama5",
        "KuriTama6",
        "KuriTama7"
    };

    // 解説たまごちゃん番号
    static public int KaiTama;
}
