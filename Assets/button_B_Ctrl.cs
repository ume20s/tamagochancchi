using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_B_Ctrl : MonoBehaviour
{
    // 音声関連
    AudioSource audioSource;
    public AudioClip seButtonB;

    // Start is called before the first frame update
    void Start()
    {
        // 音声のコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    // タップされたら
    public void onClick()
    {
        // タップ可能(in game)ならば処理
        if (GameDirector.isTappable)
        {
            GameDirector.buttonA = false;
            GameDirector.buttonB = true;

            // 効果音
            audioSource.PlayOneShot(seButtonB);
        }
    }
}
