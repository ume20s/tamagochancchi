using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c02_Ctrl : MonoBehaviour
{
    // �^�b�v������
    public void onClick()
    {
        // ������܂������ԍ����Z�b�g
        dt.KaiTama = 2;

        // ����V�[���ֈڍs
        SceneManager.LoadScene("CommentScene");
    }
}
