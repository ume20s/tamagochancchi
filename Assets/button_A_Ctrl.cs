using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_A_Ctrl : MonoBehaviour
{
    // タップされたら
    public void onClick()
    {
        // タップ可能(in game)ならば処理
        if (GameDirector.isTappable)
        {
            GameDirector.buttonA = true;
            GameDirector.buttonB = false;
        }
    }
}
