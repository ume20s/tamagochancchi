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
    int tamaMode;                               // たまごちゃん状態（0:通常 1:ごはん 2:リセット）
    int resetCounter;                           // リセット画面カウンター
    int manpukuRate;                            // 満腹度

    // ゲームオブジェクト
    GameObject[] cursor = new GameObject[5];
    GameObject tama;
    GameObject tama_reset;
    GameObject s_guage;
    GameObject t_guage;

    // スプライト
    public Sprite[] t_disp = new Sprite[7];     // 時間メーター
    public Sprite[] s_disp = new Sprite[7];     // 満腹メーター
    public Sprite[] tamaReset = new Sprite[4];  // リセット画面

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
        tama_reset = GameObject.Find("tama_reset");
        s_guage = GameObject.Find("s_guage");
        t_guage = GameObject.Find("t_guage");

        // アニメーターコンポーネントの取得
        animator = tama.GetComponent<Animator>();

        // カーソル表示の初期化
        for(int i=0; i<5; i++)
        {
            cursor[i].SetActive(false);
        }

        // ボタンフラグと通常モードの準備
        buttonA = false;
        buttonB = false;
        tamaMode = 0;
        tama_reset.SetActive(false);

        // 満腹ゲージの準備
        manpukuRate = 0;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

        // タップ不可にして孵化
        isTappable = false;
        StartCoroutine("tamaFuka");
    }

    // Update is called once per frame
    void Update()
    {
        // デバッグ用
        // Debug.Log(tamaMode + "," + resetCounter + "," + cursorPos);

        // タップ可能(in game)ならば処理
        if (isTappable)
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

            switch (tamaMode)
            {
                // 通常モード
                case 0:
                    // Aボタンが押されていた
                    if (buttonA)
                    {
                        switch (cursorPos)
                        {
                            // ごはん
                            case 0:
                                // 満腹だったらいやいや
                                if(manpukuRate == 6)
                                {
                                    StartCoroutine("tamaIyaiya");
                                }
                                // じゃなかったらごはんモードへ遷移
                                else
                                {
                                    animator.SetTrigger("gohanTrigger");
                                    tamaMode = 1;
                                }
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

                            // リセットモードへ遷移
                            case 4:
                                tama_reset.SetActive(true);
                                tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[0];
                                resetCounter = 1;
                                tamaMode = 2;
                                break;

                            // NOT REACHED
                            default:
                                break;
                        }
                        buttonA = false;
                    }
                    break;

                // ごはんモード
                case 1:
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
                        tamaMode = 0;
                        buttonA = false;
                    }

                    // Bボタンが押されていた
                    if (buttonB)
                    {
                        animator.SetTrigger("waitingTrigger");
                        tamaMode = 0;
                        buttonB = false;
                    }
                    break;

                // リセットモード
                case 2:
                    if (buttonA)
                    {
                        // リセット選択１回目
                        if(resetCounter == 1)
                        {
                            // カーソル位置が一番上「はい」だったら
                            if (cursorPos == 0)
                            {
                                // 次の画面にしてリセットカウンター加算
                                tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[1];
                                resetCounter++;
                            }
                            // それ以外なら通常モードに戻る
                            else
                            {
                                tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[0];
                                tama_reset.SetActive(false);
                                resetCounter = 0;
                                tamaMode = 0;
                            }

                        }
                        // リセット選択２回目
                        else
                        {
                            // カーソル位置が一番下「はい」だったら
                            if (cursorPos == 4)
                            {
                                // リセット画面へ遷移
                                StartCoroutine("tamaInitReset");
                            }
                            // それ以外なら通常モードに戻る
                            else
                            {
                                tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[0];
                                tama_reset.SetActive(false);
                                resetCounter = 0;
                                tamaMode = 0;
                            }
                        }
                        buttonA = false;
                    }

                    // Bボタンが押されていた
                    if (buttonB)
                    {
                        tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[0];
                        tama_reset.SetActive(false);
                        resetCounter = 0;
                        tamaMode = 0;
                        buttonB = false;
                    }
                    break;

                // NOT REACHED
                default:
                    break;
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

        // 満腹度アップ
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

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

        // 満腹度アップ
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

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

        // 満腹度アップ
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

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

        // 満腹度アップ
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

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

        // 満腹度アップ
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

        // カーソルをごはんにもどす
        cursorPos = 0;

        // タップ可能(in Game)
        isTappable = true;
    }

    // たまごちゃんいやいや
    IEnumerator tamaIyaiya()
    {
        // タップ不可
        isTappable = false;

        // アニメ遷移してウェイト
        animator.SetTrigger("iyaiyaTrigger");
        yield return new WaitForSeconds(3.0f);

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

    // たまごちゃんリセット
    IEnumerator tamaInitReset()
    {
        // タップ不可
        isTappable = false;

        // カーソル非表示
        for(int i = 1; i<5; i++)
        {
            cursor[i].SetActive(false);
        }

        // ゲージ非表示
        s_guage.SetActive(false);
        t_guage.SetActive(false);

        // 満腹度リセット
        manpukuRate = 0;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

        // アニメ遷移してウェイト
        animator.SetTrigger("resetTrigger");
        tama_reset.SetActive(false);
        yield return new WaitForSeconds(12.0f);

        // その他いろいろ初期化
        tamaMode = 0;
        resetCounter = 0;
        cursorPos = 0;
        cursor[cursorPos].SetActive(true);
        s_guage.SetActive(true);
        t_guage.SetActive(true);

        // タップ可能(in Game)
        isTappable = true;
    }
}
