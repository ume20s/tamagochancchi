using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_R_Ctrl : MonoBehaviour
{
    // タップされたら
    public void onClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}
