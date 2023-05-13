using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_B_Ctrl : MonoBehaviour
{
    // タップされたら
    public void onClick()
    {
        // タップ可能(in game)ならば処理
        if (GameDirector.isTappable)
        {
            GameDirector.buttonB = true;
        }
    }
}
