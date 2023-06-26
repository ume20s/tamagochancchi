using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_R_Ctrl : MonoBehaviour
{
    // 音声関連
    AudioSource audioSource;
    public AudioClip seButtonA;

    // Start is called before the first frame update
    void Start()
    {
        // 音声のコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // タップされたら
    public void onClick()
    {
        StartCoroutine("tapToOnceMore");
    }

    // 効果音を再生してからゲームシーンをロード
    IEnumerator tapToOnceMore()
    {
        audioSource.PlayOneShot(seButtonA);
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene("GameScene");
    }
}
