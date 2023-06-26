using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentDirector : MonoBehaviour
{
    // ゲームオブジェクト
    GameObject commentary;
    GameObject trueTamago;
    GameObject kirakira;

    // アニメーター
    Animator animatorComment;

    // 音声関連
    AudioSource audioSource;
    public AudioClip seZukanPnl;
    public AudioClip seKirakira;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの取得
        commentary = GameObject.Find("commentary");
        trueTamago = GameObject.Find("trueTamago");
        kirakira = GameObject.Find("kirakira");

        // 音声コンポーネントの取得
        audioSource = GetComponent<AudioSource>();

        // アニメーターコンポーネントの取得
        animatorComment = commentary.GetComponent<Animator>();

        // キラキラ非表示
        kirakira.SetActive(false);

        // 効果音
        StartCoroutine("pnlTapSE");

        // アニメーショントリガの設定
        switch (dt.KaiTama)
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
                StartCoroutine("tamaScroll");
                break;
            default:
                break;
        }
    }

    // あたかも図鑑パネルをタップしてすぐの効果音のように見せかける
    IEnumerator pnlTapSE()
    {
        yield return new WaitForSeconds(0.01f);
        audioSource.PlayOneShot(seZukanPnl);
    }

    // 真のたまごちゃんスクロール
    IEnumerator tamaScroll()
    {
        // キラキラ表示
        kirakira.SetActive(true);

        // スクロール
        audioSource.PlayOneShot(seKirakira);
        for (int pos = 0; pos <=268; pos++)
        {
            trueTamago.transform.Translate(0, 0.05f, 0, Space.World);
            yield return new WaitForSeconds(0.02f);
        }

        // スクロール用真たまとキラキラ非表示
        trueTamago.SetActive(false);
        kirakira.SetActive(false);

        // 解説表示
        animatorComment.SetTrigger("sono8Trigger");
    }
}