using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class splash_Ctrl : MonoBehaviour
{
    // �^�b�v���ꂽ��
    public void onClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
