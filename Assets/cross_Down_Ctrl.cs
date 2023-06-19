using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_Down_Ctrl : MonoBehaviour
{
    // 音声関連
    AudioSource audioSource;
    public AudioClip seCursor;

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
            GameDirector.cursorPos++;
            if (GameDirector.cursorPos > 4)
            {
                GameDirector.cursorPos = 4;
            }

            // 効果音
            audioSource.PlayOneShot(seCursor);
        }
    }
}
