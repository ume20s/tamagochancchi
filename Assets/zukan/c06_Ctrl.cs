using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class c06_Ctrl : MonoBehaviour
{
    // �^�b�v������
    public void onClick()
    {
        // ������܂������ԍ����Z�b�g
        dt.KaiTama = 6;

        // ����V�[���ֈڍs
        SceneManager.LoadScene("CommentScene");
    }
}
