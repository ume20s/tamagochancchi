using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_up_Ctrl : MonoBehaviour
{
    // �^�b�v���ꂽ��
    public void onClick()
    {
        // �^�b�v�\(in game)�Ȃ�Ώ���
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
