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
    int tamaMode;                               // ���܂�������ԁi0:�ʏ� 1:���͂� 2:���Z�b�g�j
    int resetCounter;                           // ���Z�b�g��ʃJ�E���^�[
    int manpukuRate;                            // �����x

    // �Q�[���I�u�W�F�N�g
    GameObject[] cursor = new GameObject[5];
    GameObject tama;
    GameObject tama_reset;
    GameObject s_guage;
    GameObject t_guage;

    // �X�v���C�g
    public Sprite[] t_disp = new Sprite[7];     // ���ԃ��[�^�[
    public Sprite[] s_disp = new Sprite[7];     // �������[�^�[
    public Sprite[] tamaReset = new Sprite[4];  // ���Z�b�g���

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
        tama_reset = GameObject.Find("tama_reset");
        s_guage = GameObject.Find("s_guage");
        t_guage = GameObject.Find("t_guage");

        // �A�j���[�^�[�R���|�[�l���g�̎擾
        animator = tama.GetComponent<Animator>();

        // �J�[�\���\���̏�����
        for(int i=0; i<5; i++)
        {
            cursor[i].SetActive(false);
        }

        // �{�^���t���O�ƒʏ탂�[�h�̏���
        buttonA = false;
        buttonB = false;
        tamaMode = 0;
        tama_reset.SetActive(false);

        // �����Q�[�W�̏���
        manpukuRate = 0;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

        // �^�b�v�s�ɂ��ěz��
        isTappable = false;
        StartCoroutine("tamaFuka");
    }

    // Update is called once per frame
    void Update()
    {
        // �f�o�b�O�p
        // Debug.Log(tamaMode + "," + resetCounter + "," + cursorPos);

        // �^�b�v�\(in game)�Ȃ�Ώ���
        if (isTappable)
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

            switch (tamaMode)
            {
                // �ʏ탂�[�h
                case 0:
                    // A�{�^����������Ă���
                    if (buttonA)
                    {
                        switch (cursorPos)
                        {
                            // ���͂�
                            case 0:
                                // �����������炢�₢��
                                if(manpukuRate == 6)
                                {
                                    StartCoroutine("tamaIyaiya");
                                }
                                // ����Ȃ������炲�͂񃂁[�h�֑J��
                                else
                                {
                                    animator.SetTrigger("gohanTrigger");
                                    tamaMode = 1;
                                }
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

                            // ���Z�b�g���[�h�֑J��
                            case 4:
                                tama_reset.SetActive(true);
                                tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[0];
                                resetCounter = 1;
                                tamaMode = 2;
                                break;

                            // NOT REACHED
                            default:
                                break;
                        }
                        buttonA = false;
                    }
                    break;

                // ���͂񃂁[�h
                case 1:
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
                        tamaMode = 0;
                        buttonA = false;
                    }

                    // B�{�^����������Ă���
                    if (buttonB)
                    {
                        animator.SetTrigger("waitingTrigger");
                        tamaMode = 0;
                        buttonB = false;
                    }
                    break;

                // ���Z�b�g���[�h
                case 2:
                    if (buttonA)
                    {
                        // ���Z�b�g�I���P���
                        if(resetCounter == 1)
                        {
                            // �J�[�\���ʒu����ԏ�u�͂��v��������
                            if (cursorPos == 0)
                            {
                                // ���̉�ʂɂ��ă��Z�b�g�J�E���^�[���Z
                                tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[1];
                                resetCounter++;
                            }
                            // ����ȊO�Ȃ�ʏ탂�[�h�ɖ߂�
                            else
                            {
                                tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[0];
                                tama_reset.SetActive(false);
                                resetCounter = 0;
                                tamaMode = 0;
                            }

                        }
                        // ���Z�b�g�I���Q���
                        else
                        {
                            // �J�[�\���ʒu����ԉ��u�͂��v��������
                            if (cursorPos == 4)
                            {
                                // ���Z�b�g��ʂ֑J��
                                StartCoroutine("tamaInitReset");
                            }
                            // ����ȊO�Ȃ�ʏ탂�[�h�ɖ߂�
                            else
                            {
                                tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[0];
                                tama_reset.SetActive(false);
                                resetCounter = 0;
                                tamaMode = 0;
                            }
                        }
                        buttonA = false;
                    }

                    // B�{�^����������Ă���
                    if (buttonB)
                    {
                        tama_reset.GetComponent<SpriteRenderer>().sprite = tamaReset[0];
                        tama_reset.SetActive(false);
                        resetCounter = 0;
                        tamaMode = 0;
                        buttonB = false;
                    }
                    break;

                // NOT REACHED
                default:
                    break;
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

        // �����x�A�b�v
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

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

        // �����x�A�b�v
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

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

        // �����x�A�b�v
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

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

        // �����x�A�b�v
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

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

        // �����x�A�b�v
        manpukuRate++;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

        // �J�[�\�������͂�ɂ��ǂ�
        cursorPos = 0;

        // �^�b�v�\(in Game)
        isTappable = true;
    }

    // ���܂�����񂢂₢��
    IEnumerator tamaIyaiya()
    {
        // �^�b�v�s��
        isTappable = false;

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("iyaiyaTrigger");
        yield return new WaitForSeconds(3.0f);

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

    // ���܂�����񃊃Z�b�g
    IEnumerator tamaInitReset()
    {
        // �^�b�v�s��
        isTappable = false;

        // �J�[�\����\��
        for(int i = 1; i<5; i++)
        {
            cursor[i].SetActive(false);
        }

        // �Q�[�W��\��
        s_guage.SetActive(false);
        t_guage.SetActive(false);

        // �����x���Z�b�g
        manpukuRate = 0;
        s_guage.GetComponent<SpriteRenderer>().sprite = s_disp[manpukuRate];

        // �A�j���J�ڂ��ăE�F�C�g
        animator.SetTrigger("resetTrigger");
        tama_reset.SetActive(false);
        yield return new WaitForSeconds(12.0f);

        // ���̑����낢�돉����
        tamaMode = 0;
        resetCounter = 0;
        cursorPos = 0;
        cursor[cursorPos].SetActive(true);
        s_guage.SetActive(true);
        t_guage.SetActive(true);

        // �^�b�v�\(in Game)
        isTappable = true;
    }
}
