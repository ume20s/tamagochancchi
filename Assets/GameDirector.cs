using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    // 変数もろもろ
    public static int cursorPos;                // カーソル位置
    public static bool buttonA;                 // Aボタンフラグ
    public static bool buttonB;                 // Bボタンフラグ
    public static bool isTappable;              // タップ可能
    bool gohanMode;                             // ごはんモード

    // ゲームオブジェクト
    GameObject[] cursor = new GameObject[5];
    GameObject tama;

    // アニメーター
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // オブジェクトの取得
        cursor[0] = GameObject.Find("cursor0");
        cursor[1] = GameObject.Find("cursor1");
        cursor[2] = GameObject.Find("cursor2");
        cursor[3] = GameObject.Find("cursor3");
        cursor[4] = GameObject.Find("cursor4");
        tama = GameObject.Find("tama");

        // アニメーターコンポーネントの取得
        animator = tama.GetComponent<Animator>();

        // カーソル表示の初期化
        for(int i=0; i<5; i++)
        {
            cursor[i].SetActive(false);
        }

        // ボタンフラグとごはんモードの初期化
        buttonA = false;
        buttonB = false;
        gohanMode = false;

        // タップ不可にして孵化
        isTappable = false;
        StartCoroutine("tamaFuka");
    }

    // Update is called once per frame
    void Update()
    {
        // タップ可能(in game)ならば処理
        if(isTappable)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == cursorPos)
                {
                    cursor[i].SetActive(true);
                }
                else
                {
                    cursor[i].SetActive(false);
                }
            }

            // ごはんモードだったら
            if (gohanMode)
            {
                // Aボタンが押されていた
                if (buttonA)
                {
                    switch (cursorPos)
                    {
                        // 納豆
                        case 0:
                            StartCoroutine("tamaNatto");
                            break;

                        // ラーメン
                        case 1:
                            StartCoroutine("tamaRamen");
                            break;

                        // 寿司
                        case 2:
                            StartCoroutine("tamaSushi");
                            break;

                        // ウナギ弁当
                        case 3:
                            StartCoroutine("tamaUnagi");
                            break;

                        // プラモデル
                        case 4:
                            StartCoroutine("tamaPramo");
                            break;

                        // NOT REACHED
                        default:
                            break;
                    }
                    gohanMode = false;
                    buttonA = false;
                }

                // Bボタンが押されていた
                if (buttonB)
                {
                    animator.SetTrigger("waitingTrigger");
                    gohanMode = false;
                    buttonB = false;
                }
            }
            // 通常モードだったら
            else
            {
                // Aボタンが押されていた
                if (buttonA)
                {
                    switch (cursorPos)
                    {
                        // ごはん
                        case 0:
                            animator.SetTrigger("gohanTrigger");
                            gohanMode = true;
                            break;

                        // お風呂
                        case 1:
                            StartCoroutine("tamaBath");
                            break;

                        // ギター
                        case 2:
                            StartCoroutine("tamaGuitar");
                            break;

                        // 通報
                        case 3:
                            StartCoroutine("tamaTuho");
                            break;

                        // NOT REACHED
                        default:
                            break;
                    }
                    buttonA = false;
                }
            }
        }
    }

    // たまごちゃん孵化
    IEnumerator tamaFuka()
    {
        // タップ不可
        isTappable = false;

        // 孵化アニメのウエイト
        yield return new WaitForSeconds(9.0f);

        // カーソル表示
        cursorPos = 0;
        cursor[cursorPos].SetActive(true);

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃん納豆
    IEnumerator tamaNatto()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("nattoTrigger");
        yield return new WaitForSeconds(6.5f);

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃんラーメン
    IEnumerator tamaRamen()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("ramenTrigger");
        yield return new WaitForSeconds(4.0f);

        // カーソルをごはんにもどす
        cursorPos = 0;

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃん寿司
    IEnumerator tamaSushi()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("sushiTrigger");
        yield return new WaitForSeconds(3.3f);

        // カーソルをごはんにもどす
        cursorPos = 0;

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃん鰻弁当
    IEnumerator tamaUnagi()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("unagiTrigger");
        yield return new WaitForSeconds(3.66f);

        // カーソルをごはんにもどす
        cursorPos = 0;

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃんプラモ
    IEnumerator tamaPramo()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("pramoTrigger");
        yield return new WaitForSeconds(4.0f);

        // カーソルをごはんにもどす
        cursorPos = 0;

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃんお風呂
    IEnumerator tamaBath()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("bathTrigger");
        yield return new WaitForSeconds(3.0f);

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃんギター
    IEnumerator tamaGuitar()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("guitarTrigger");
        yield return new WaitForSeconds(3.0f);

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃん通報
    IEnumerator tamaTuho()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("tuhoTrigger");
        yield return new WaitForSeconds(5.0f);

        // タップ可能(in Game)
        isTappable = true;
    }
}
