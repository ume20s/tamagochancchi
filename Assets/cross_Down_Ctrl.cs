using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_Down_Ctrl : MonoBehaviour
{
    // タップされたら
    public void onClick()
    {
        GameDirector.cursorPos++;
        if (GameDirector.cursorPos > 4)
        {
            GameDirector.cursorPos = 4;
        }
    }
}
