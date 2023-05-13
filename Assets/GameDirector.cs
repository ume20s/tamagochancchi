using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    // �ϐ��������
    public static int cursorPos;                // �J�[�\���ʒu
    public static bool buttonA;                 // A�{�^���t���O
    public static bool buttonB;                 // B�{�^���t���O
    public static bool isTappable;              // �^�b�v�\
    bool gohanMode;                             // ���͂񃂁[�h

    // �Q�[���I�u�W�F�N�g
    GameObject[] cursor = new GameObject[5];
    GameObject tama;

    // �A�j���[�^�[
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // �I�u�W�F�N�g�̎擾
        cursor[0] = GameObject.Find("cursor0");
        cursor[1] = GameObject.Find("cursor1");
        cursor[2] = GameObject.Find("cursor2");
        cursor[3] = GameObject.Find("cursor3");
        cursor[4] = GameObject.Find("cursor4");
        tama = GameObject.Find("tama");

        // �A�j���[�^�[�R���|�[�l���g�̎擾
        animator = tama.GetComponent<Animator>();

        // �J�[�\���\���̏�����
        for(int i=0; i<5; i++)
        {
            cursor[i].SetActive(false);
        }

        // �{�^���t���O�Ƃ��͂񃂁[�h�̏�����
        buttonA = false;
        buttonB = false;
        gohanMode = false;

        // �^�b�v�s�ɂ��ěz��
        isTappable = false;
        StartCoroutine("tamaFuka");
    }

    // Update is called once per frame
    void Update()
    {
        // �^�b�v�\(in game)�Ȃ�Ώ���
        if(isTappable)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == cursorPos)
                {
                    cursor[i].SetActive(true);
                }
                else
                {
                    cursor[i].SetActive(false);
                }
            }

            // ���͂񃂁[�h��������
            if (gohanMode)
            {
                // A�{�^����������Ă���
                if (buttonA)
                {
                    switch (cursorPos)
                    {
                        // �[��
                        case 0:
                            StartCoroutine("tamaNatto");
                            break;

                        // ���[����
                        case 1:
                            StartCoroutine("tamaRamen");
                            break;

                        // ���i
                        case 2:
                            StartCoroutine("tamaSushi");
                            break;

                        // �E�i�M�ٓ�
                        case 3:
                            StartCoroutine("tamaUnagi");
                            break;

                        // �v�����f��
                        case 4:
                            StartCoroutine("tamaPramo");
                            break;

                        // NOT REACHED
                        default:
                            break;
                    }
                    gohanMode = false;
                    buttonA = false;
                }

                // B�{�^����������Ă���
                if (buttonB)
                {
                    animator.SetTrigger("waitingTrigger");
                    gohanMode = false;
                    buttonB = false;
                }
            }
            // �ʏ탂�[�h��������
            else
            {
                // A�{�^����������Ă���
                if (buttonA)
                {
                    switch (cursorPos)
                    {
                        // ���͂�
                        case 0:
                            animator.SetTrigger("gohanTrigger");
                            gohanMode = true;
                            break;

                        // �����C
                        case 1:
                            StartCoroutine("tamaBath");
                            break;

                        // �M�^�[
                        case 2:
                            StartCoroutine("tamaGuitar");
                            break;

                        // �ʕ�
                        case 3:
                            StartCoroutine("tamaTuho");
                            break;

                        // NOT REACHED
                        default:
                            break;
                    }
                    buttonA = false;
                }
            }
        }
    }

    // ���܂������z��
    IEnumerator tamaFuka()
    {
        // �^�b�v�s��
        isTappable = false;

        // �z���A�j���̃E�G�C�g
        yield return new WaitForSeconds(9.0f);

        // �J�[�\���\��
        cursorPos = 0;
        cursor[cursorPos].SetActive(true);

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂������[��
    IEnumerator tamaNatto()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("nattoTrigger");
        yield return new WaitForSeconds(6.5f);

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂�����񃉁[����
    IEnumerator tamaRamen()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("ramenTrigger");
        yield return new WaitForSeconds(4.0f);

        // �J�[�\�������͂�ɂ��ǂ�
        cursorPos = 0;

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂��������i
    IEnumerator tamaSushi()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("sushiTrigger");
        yield return new WaitForSeconds(3.3f);

        // �J�[�\�������͂�ɂ��ǂ�
        cursorPos = 0;

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂������V�ٓ�
    IEnumerator tamaUnagi()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("unagiTrigger");
        yield return new WaitForSeconds(3.66f);

        // �J�[�\�������͂�ɂ��ǂ�
        cursorPos = 0;

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂������v����
    IEnumerator tamaPramo()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("pramoTrigger");
        yield return new WaitForSeconds(4.0f);

        // �J�[�\�������͂�ɂ��ǂ�
        cursorPos = 0;

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂�����񂨕��C
    IEnumerator tamaBath()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("bathTrigger");
        yield return new WaitForSeconds(3.0f);

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂������M�^�[
    IEnumerator tamaGuitar()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("guitarTrigger");
        yield return new WaitForSeconds(3.0f);

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂������ʕ�
    IEnumerator tamaTuho()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("tuhoTrigger");
        yield return new WaitForSeconds(5.0f);

        // �^�b�v�\(in Game)
        isTappable = true;
    }
}
