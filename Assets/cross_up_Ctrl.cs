using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_up_Ctrl : MonoBehaviour
{
    // タップされたら
    public void onClick()
    {
        // タップ可能(in game)ならば処理
        if (GameDirector.isTappable)
        {
            GameDirector.cursorPos--;
            if (GameDirector.cursorPos < 0)
            {
                GameDirector.cursorPos = 0;
            }
        }
    }
}
