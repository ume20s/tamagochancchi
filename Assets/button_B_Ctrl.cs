using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_B_Ctrl : MonoBehaviour
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
        // �^�b�v�\(in game)�Ȃ�Ώ���
        if (GameDirector.isTappable)
        {
            GameDirector.buttonA = false;
            GameDirector.buttonB = true;

            // ���ʉ�
            audioSource.PlayOneShot(seButtonB);
        }
    }
}
