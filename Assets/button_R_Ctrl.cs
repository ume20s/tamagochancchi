using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button_R_Ctrl : MonoBehaviour
{
    // �����֘A
    AudioSource audioSource;
    public AudioClip seButtonA;

    // Start is called before the first frame update
    void Start()
    {
        // �����̃R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();
    }

    // �^�b�v���ꂽ��
    public void onClick()
    {
        StartCoroutine("tapToOnceMore");
    }

    // ���ʉ����Đ����Ă���Q�[���V�[�������[�h
    IEnumerator tapToOnceMore()
    {
        audioSource.PlayOneShot(seButtonA);
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene("GameScene");
    }
}
