using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_A_Ctrl : MonoBehaviour
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
        // �^�b�v�\(in game)�Ȃ�Ώ���
        if (GameDirector.isTappable)
        {
            GameDirector.buttonA = true;
            GameDirector.buttonB = false;

            // ���ʉ�
            audioSource.PlayOneShot(seButtonA);
        }
    }
}
