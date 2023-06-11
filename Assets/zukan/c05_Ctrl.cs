using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c05_Ctrl : MonoBehaviour
{
    // タップしたら
    public void onClick()
    {
        // 解説たまごちゃん番号をセット
        dt.KaiTama = 5;

        // 解説シーンへ移行
        SceneManager.LoadScene("CommentScene");
    }
}
