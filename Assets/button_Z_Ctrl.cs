using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_Z_Ctrl : MonoBehaviour
{
    // タップされたら
    public void onClick()
    {
        SceneManager.LoadScene("ZukanScene");
    }
}
