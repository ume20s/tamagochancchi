using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_B_Ctrl : MonoBehaviour
{
    // �^�b�v���ꂽ��
    public void onClick()
    {
        // �^�b�v�\(in game)�Ȃ�Ώ���
        if (GameDirector.isTappable)
        {
            GameDirector.buttonB = true;
        }
    }
}
