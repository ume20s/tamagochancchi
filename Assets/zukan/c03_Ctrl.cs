using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c03_Ctrl : MonoBehaviour
{
    // �^�b�v������
    public void onClick()
    {
        // ������܂������ԍ����Z�b�g
        dt.KaiTama = 3;

        // ����V�[���ֈڍs
        SceneManager.LoadScene("CommentScene");
    }
}