using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross_Down_Ctrl : MonoBehaviour
{
    // �����֘A
    AudioSource audioSource;
    public AudioClip seCursor;

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
            GameDirector.cursorPos++;
            if (GameDirector.cursorPos > 4)
            {
                GameDirector.cursorPos = 4;
            }

            // ���ʉ�
            audioSource.PlayOneShot(seCursor);
        }
    }
}
