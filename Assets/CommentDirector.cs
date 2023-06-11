using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentDirector : MonoBehaviour
{
    // ゲームオブジェクト
    GameObject commentary;

    // アニメーター
    Animator animatorComment;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの取得
        commentary = GameObject.Find("commentary");

        // アニメーターコンポーネントの取得
        animatorComment = commentary.GetComponent<Animator>();

        // アニメーショントリガの設定
        switch(dt.KaiTama)
        {
            case 0:
                animatorComment.SetTrigger("sono1Trigger");
                break;
            case 1:
                animatorComment.SetTrigger("sono2Trigger");
                break;
            case 2:
                animatorComment.SetTrigger("sono3Trigger");
                break;
            case 3:
                animatorComment.SetTrigger("sono4Trigger");
                break;
            case 4:
                animatorComment.SetTrigger("sono5Trigger");
                break;
            case 5:
                animatorComment.SetTrigger("sono6Trigger");
                break;
            case 6:
                animatorComment.SetTrigger("sono7Trigger");
                break;
            case 7:
                animatorComment.SetTrigger("sono8Trigger");
                break;
            default:
                break;
        }
    }
}
