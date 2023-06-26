using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_M_Ctrl : MonoBehaviour
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
        StartCoroutine("tapToZukan");
    }

    // 効果音を再生してから図鑑シーンをロード
    IEnumerator tapToZukan()
    {
        audioSource.PlayOneShot(seButtonB);
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene("ZukanScene");
    }
}
