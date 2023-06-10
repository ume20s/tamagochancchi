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
    private int tamaMode;                       // たまごちゃん状態（0:通常 1:ごはん 2:リセット 3:最終形態）
    private int resetCounter;                   // リセット画面カウンター
    private float remainTime = 72.999f;         // 残り時間
    private int manpukuRate;                    // 満腹度
    private int[] selected = new int[10];       // コマンド選択回数

    // ゲームオブジェクト
    GameObject[] cursor = new GameObject[5];
    GameObject tama;
    GameObject tama_reset;
    GameObject s_guage;
    GameObject t_guage;
    GameObject henshin;
    GameObject last;
    GameObject last07;
    GameObject button_R;
    GameObject button_Z;

    // スプライト
    public Sprite[] t_disp = new Sprite[7];     // 時間メーター
    public Sprite[] s_disp = new Sprite[7];     // 満腹メーター
    public Sprite[] tamaReset = new Sprite[4];  // リセット画面
    public Sprite[] last_form = new Sprite[7];  // 最終形態

    // アニメーター
    Animator animatorTama;
    Animator animatorHenshin;

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
        henshin = GameObject.Find("henshin");
        last = GameObject.Find("last");
        last07 = GameObject.Find("last07");
        button_R = GameObject.Find("button_R");
        button_Z = GameObject.Find("button_Z");

        // アニメーターコンポーネントの取得
        animatorTama = tama.GetComponent<Animator>();
        animatorHenshin = henshin.GetComponent<Animator>();

        // カーソル表示の初期化
        for(int i=0; i<5; i++)
        {
            cursor[i].SetActive(false);
        }

        // 選択回数の初期化
        for(int i=0; i<10; i++)
        {
            selected[i] = 0;
        }

        // ボタンフラグと通常モードの準備
        buttonA = false;
        buttonB = false;
        tamaMode = 0;
        tama_reset.SetActive(false);

        // 図鑑ともう一回ボタンを非表示に
        button_Z.SetActive(false);
        button_R.SetActive(false);

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
        // Debug.Log(selected[0] + "," + selected[1] + "," + selected[7]);

        // 時間経過
        remainTime -= Time.deltaTime;
        if(remainTime > 60.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[6];
        }
        else if (remainTime > 50.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[5];
        }
        else if (remainTime > 40.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[4];
        }
        else if (remainTime > 30.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[3];
        }
        else if (remainTime > 20.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[2];
        }
        else if (remainTime > 10.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[1];
        }
        else
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[0];
        }

        // 残り時間がなくなったら最終形態
        if ((int)remainTime <= 0)
        {
            tamaMode = 4;
        }


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
                                    animatorTama.SetTrigger("gohanTrigger");
                                    tamaMode = 1;
                                }
                                break;

                            // お風呂
                            case 1:
                                selected[5]++;
                                StartCoroutine("tamaBath");
                                break;

                            // ギター
                            case 2:
                                selected[6]++;
                                StartCoroutine("tamaGuitar");
                                break;

                            // 通報
                            case 3:
                                selected[7]++;
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
                                selected[0]++;
                                StartCoroutine("tamaNatto");
                                break;

                            // ラーメン
                            case 1:
                                selected[1]++;
                                StartCoroutine("tamaRamen");
                                break;

                            // 寿司
                            case 2:
                                selected[2]++;
                                StartCoroutine("tamaSushi");
                                break;

                            // ウナギ弁当
                            case 3:
                                selected[3]++;
                                StartCoroutine("tamaUnagi");
                                break;

                            // プラモデル
                            case 4:
                                selected[4]++;
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
                        animatorTama.SetTrigger("waitingTrigger");
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

                // 最終形態モード
                case 4:
                    StartCoroutine("tamaLast");
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
        animatorTama.SetTrigger("nattoTrigger");
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
        animatorTama.SetTrigger("ramenTrigger");
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
        animatorTama.SetTrigger("sushiTrigger");
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
        animatorTama.SetTrigger("unagiTrigger");
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
        animatorTama.SetTrigger("pramoTrigger");
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
        animatorTama.SetTrigger("iyaiyaTrigger");
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
        animatorTama.SetTrigger("bathTrigger");
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
        animatorTama.SetTrigger("guitarTrigger");
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
        animatorTama.SetTrigger("tuhoTrigger");
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
        animatorTama.SetTrigger("resetTrigger");
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

    // たまごちゃん最終形態
    IEnumerator tamaLast()
    {
        // タップ不可
        isTappable = false;

        // 変身モーション（本体ブルブル）
        henshin.GetComponent<Renderer>().sortingOrder = 5;
        animatorHenshin.SetTrigger("start");
        yield return new WaitForSeconds(7.0f);

        // 最終形態の表示
        // プラモ以外を２回食べたら その８「真の姿」
        if (selected[0] == 2 && selected[1] == 2 && selected[2] == 2 && selected[3] == 2 && selected[4] == 0)
        {
            // ズームして
            last07.transform.localScale = new Vector2(0.0f, 0.0f);
            last07.GetComponent<Renderer>().sortingOrder = 6;
            for (float scale = 0.0f; scale <= 1.1f; scale += 0.1f)
            {
                last07.transform.localScale = new Vector2(scale, scale);
                yield return new WaitForSeconds(0.1f);
            }

            // ちょっと待って
            yield return new WaitForSeconds(0.7f);
            
            // スクロール
            for (int pos = 0; pos < 70; pos++)
            {
                last07.transform.Translate(0, 0.2f, 0, Space.World);
                yield return new WaitForSeconds(0.05f);
            }
        }
        // 通常の最終形態
        else
        {
            // 一度でも通報されていたら その１
            if (selected[7] > 0)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[0];
            }
            // ギター３回なら その２
            else if (selected[6] == 3)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[1];
            }
            // 納豆ばかりで満腹なら その５
            else if (selected[0] > 5 && selected[1] == 0 && selected[2] == 0 && selected[3] == 0 && selected[4] == 0)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[4];
            }
            // ラーメンばかりで満腹なら その７
            else if(selected[0] ==0 && selected[1] > 5 && selected[2] == 0 && selected[3] == 0 && selected[4] == 0)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[6];
            }
            // お風呂３回以上なら その６
            else if (selected[5] >= 3)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[5];
            }
            // プラモ２回以上なら その３
            else if (selected[4] >= 2)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[2];
            }
            // それ以外なら その４
            else
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[3];
            }

            // ズームして表示
            last.transform.localScale = new Vector2(0.0f, 0.0f);
            last.GetComponent<Renderer>().sortingOrder = 6;
            for (float scale = 0.0f; scale <= 1.1f; scale += 0.1f)
            {
                last.transform.localScale = new Vector2(scale, scale);
                yield return new WaitForSeconds(0.1f);
            }
        }

        // 図鑑ともう一回ボタンの表示
        button_Z.SetActive(true);
        button_R.SetActive(true);
    }
}
