using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_M_Ctrl : MonoBehaviour
{
    // �����֘A
    AudioSource audioSource;
    public AudioClip seButtonB;

    // Start is called before the first frame update
    void Start()
    {
        // �����̃R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();
    }

    // �^�b�v���ꂽ��
    public void onClick()
    {
        StartCoroutine("tapToZukan");
    }

    // ���ʉ����Đ����Ă���}�ӃV�[�������[�h
    IEnumerator tapToZukan()
    {
        audioSource.PlayOneShot(seButtonB);
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene("ZukanScene");
    }
}
