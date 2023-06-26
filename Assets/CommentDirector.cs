using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommentDirector : MonoBehaviour
{
    // �Q�[���I�u�W�F�N�g
    GameObject commentary;
    GameObject trueTamago;
    GameObject kirakira;

    // �A�j���[�^�[
    Animator animatorComment;

    // �����֘A
    AudioSource audioSource;
    public AudioClip seZukanPnl;
    public AudioClip seKirakira;

    // Start is called before the first frame update
    void Start()
    {
        // �I�u�W�F�N�g�̎擾
        commentary = GameObject.Find("commentary");
        trueTamago = GameObject.Find("trueTamago");
        kirakira = GameObject.Find("kirakira");

        // �����R���|�[�l���g�̎擾
        audioSource = GetComponent<AudioSource>();

        // �A�j���[�^�[�R���|�[�l���g�̎擾
        animatorComment = commentary.GetComponent<Animator>();

        // �L���L����\��
        kirakira.SetActive(false);

        // ���ʉ�
        StartCoroutine("pnlTapSE");

        // �A�j���[�V�����g���K�̐ݒ�
        switch (dt.KaiTama)
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
                StartCoroutine("tamaScroll");
                break;
            default:
                break;
        }
    }

    // ���������}�Ӄp�l�����^�b�v���Ă����̌��ʉ��̂悤�Ɍ���������
    IEnumerator pnlTapSE()
    {
        yield return new WaitForSeconds(0.01f);
        audioSource.PlayOneShot(seZukanPnl);
    }

    // �^�̂��܂������X�N���[��
    IEnumerator tamaScroll()
    {
        // �L���L���\��
        kirakira.SetActive(true);

        // �X�N���[��
        audioSource.PlayOneShot(seKirakira);
        for (int pos = 0; pos <=268; pos++)
        {
            trueTamago.transform.Translate(0, 0.05f, 0, Space.World);
            yield return new WaitForSeconds(0.02f);
        }

        // �X�N���[���p�^���܂ƃL���L����\��
        trueTamago.SetActive(false);
        kirakira.SetActive(false);

        // ����\��
        animatorComment.SetTrigger("sono8Trigger");
    }
}