using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c02_Ctrl : MonoBehaviour
{
    // タップしたら
    public void onClick()
    {
        // 解説たまごちゃん番号をセット
        dt.KaiTama = 2;

        // 解説シーンへ移行
        SceneManager.LoadScene("CommentScene");
    }
}
