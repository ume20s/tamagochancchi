using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentDirector : MonoBehaviour
{
    // �Q�[���I�u�W�F�N�g
    GameObject commentary;

    // �A�j���[�^�[
    Animator animatorComment;

    // Start is called before the first frame update
    void Start()
    {
        // �I�u�W�F�N�g�̎擾
        commentary = GameObject.Find("commentary");

        // �A�j���[�^�[�R���|�[�l���g�̎擾
        animatorComment = commentary.GetComponent<Animator>();

        // �A�j���[�V�����g���K�̐ݒ�
        switch(dt.KaiTama)
        {
            case 0:
                animatorComment.SetTrigger("sono1Trigger");
                break;
            case 1:
                animatorComment.SetTrigger("sono2Trigger");
                break;
            case 2:
                animatorComment.SetTrigger("sono3Trigger");
                break;
            case 3:
                animatorComment.SetTrigger("sono4Trigger");
                break;
            case 4:
                animatorComment.SetTrigger("sono5Trigger");
                break;
            case 5:
                animatorComment.SetTrigger("sono6Trigger");
                break;
            case 6:
                animatorComment.SetTrigger("sono7Trigger");
                break;
            case 7:
                animatorComment.SetTrigger("sono8Trigger");
                break;
            default:
                break;
        }
    }
}
