using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_M_Ctrl : MonoBehaviour
{
    // タップされたら
    public void onClick()
    {
        SceneManager.LoadScene("ZukanScene");
    }
}
