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
    private int tamaMode;                       // ���܂�������ԁi0:�ʏ� 1:���͂� 2:���Z�b�g 3:�ŏI�`�ԁj
    private int resetCounter;                   // ���Z�b�g��ʃJ�E���^�[
    private float remainTime = 72.999f;         // �c�莞��
    private int manpukuRate;                    // �����x
    private int[] selected = new int[10];       // �R�}���h�I����

    // �Q�[���I�u�W�F�N�g
    GameObject[] cursor = new GameObject[5];
    GameObject tama;
    GameObject tama_reset;
    GameObject s_guage;
    GameObject t_guage;
    GameObject henshin;
    GameObject last;
    GameObject last07;
    GameObject button_R;
    GameObject button_Z;

    // �X�v���C�g
    public Sprite[] t_disp = new Sprite[7];     // ���ԃ��[�^�[
    public Sprite[] s_disp = new Sprite[7];     // �������[�^�[
    public Sprite[] tamaReset = new Sprite[4];  // ���Z�b�g���
    public Sprite[] last_form = new Sprite[7];  // �ŏI�`��

    // �A�j���[�^�[
    Animator animatorTama;
    Animator animatorHenshin;

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
        henshin = GameObject.Find("henshin");
        last = GameObject.Find("last");
        last07 = GameObject.Find("last07");
        button_R = GameObject.Find("button_R");
        button_Z = GameObject.Find("button_Z");

        // �A�j���[�^�[�R���|�[�l���g�̎擾
        animatorTama = tama.GetComponent<Animator>();
        animatorHenshin = henshin.GetComponent<Animator>();

        // �J�[�\���\���̏�����
        for(int i=0; i<5; i++)
        {
            cursor[i].SetActive(false);
        }

        // �I���񐔂̏�����
        for(int i=0; i<10; i++)
        {
            selected[i] = 0;
        }

        // �{�^���t���O�ƒʏ탂�[�h�̏���
        buttonA = false;
        buttonB = false;
        tamaMode = 0;
        tama_reset.SetActive(false);

        // �}�ӂƂ������{�^�����\����
        button_Z.SetActive(false);
        button_R.SetActive(false);

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
        // Debug.Log(selected[0] + "," + selected[1] + "," + selected[7]);

        // ���Ԍo��
        remainTime -= Time.deltaTime;
        if(remainTime > 60.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[6];
        }
        else if (remainTime > 50.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[5];
        }
        else if (remainTime > 40.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[4];
        }
        else if (remainTime > 30.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[3];
        }
        else if (remainTime > 20.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[2];
        }
        else if (remainTime > 10.0f)
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[1];
        }
        else
        {
            t_guage.GetComponent<SpriteRenderer>().sprite = t_disp[0];
        }

        // �c�莞�Ԃ��Ȃ��Ȃ�����ŏI�`��
        if ((int)remainTime <= 0)
        {
            tamaMode = 4;
        }


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
                                    animatorTama.SetTrigger("gohanTrigger");
                                    tamaMode = 1;
                                }
                                break;

                            // �����C
                            case 1:
                                selected[5]++;
                                StartCoroutine("tamaBath");
                                break;

                            // �M�^�[
                            case 2:
                                selected[6]++;
                                StartCoroutine("tamaGuitar");
                                break;

                            // �ʕ�
                            case 3:
                                selected[7]++;
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
                                selected[0]++;
                                StartCoroutine("tamaNatto");
                                break;

                            // ���[����
                            case 1:
                                selected[1]++;
                                StartCoroutine("tamaRamen");
                                break;

                            // ���i
                            case 2:
                                selected[2]++;
                                StartCoroutine("tamaSushi");
                                break;

                            // �E�i�M�ٓ�
                            case 3:
                                selected[3]++;
                                StartCoroutine("tamaUnagi");
                                break;

                            // �v�����f��
                            case 4:
                                selected[4]++;
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
                        animatorTama.SetTrigger("waitingTrigger");
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

                // �ŏI�`�ԃ��[�h
                case 4:
                    StartCoroutine("tamaLast");
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
        animatorTama.SetTrigger("nattoTrigger");
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
        animatorTama.SetTrigger("ramenTrigger");
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
        animatorTama.SetTrigger("sushiTrigger");
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
        animatorTama.SetTrigger("unagiTrigger");
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
        animatorTama.SetTrigger("pramoTrigger");
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
        animatorTama.SetTrigger("iyaiyaTrigger");
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
        animatorTama.SetTrigger("bathTrigger");
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
        animatorTama.SetTrigger("guitarTrigger");
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
        animatorTama.SetTrigger("tuhoTrigger");
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
        animatorTama.SetTrigger("resetTrigger");
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

    // ���܂������ŏI�`��
    IEnumerator tamaLast()
    {
        // �^�b�v�s��
        isTappable = false;

        // �ϐg���[�V�����i�{�̃u���u���j
        henshin.GetComponent<Renderer>().sortingOrder = 5;
        animatorHenshin.SetTrigger("start");
        yield return new WaitForSeconds(7.0f);

        // �ŏI�`�Ԃ̕\��
        // �v�����ȊO���Q��H�ׂ��� ���̂W�u�^�̎p�v
        if (selected[0] == 2 && selected[1] == 2 && selected[2] == 2 && selected[3] == 2 && selected[4] == 0)
        {
            // �Y�[������
            last07.transform.localScale = new Vector2(0.0f, 0.0f);
            last07.GetComponent<Renderer>().sortingOrder = 6;
            for (float scale = 0.0f; scale <= 1.1f; scale += 0.1f)
            {
                last07.transform.localScale = new Vector2(scale, scale);
                yield return new WaitForSeconds(0.1f);
            }

            // ������Ƒ҂���
            yield return new WaitForSeconds(0.7f);
            
            // �X�N���[��
            for (int pos = 0; pos < 70; pos++)
            {
                last07.transform.Translate(0, 0.2f, 0, Space.World);
                yield return new WaitForSeconds(0.05f);
            }
        }
        // �ʏ�̍ŏI�`��
        else
        {
            // ��x�ł��ʕ񂳂�Ă����� ���̂P
            if (selected[7] > 0)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[0];
            }
            // �M�^�[�R��Ȃ� ���̂Q
            else if (selected[6] == 3)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[1];
            }
            // �[���΂���Ŗ����Ȃ� ���̂T
            else if (selected[0] > 5 && selected[1] == 0 && selected[2] == 0 && selected[3] == 0 && selected[4] == 0)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[4];
            }
            // ���[�����΂���Ŗ����Ȃ� ���̂V
            else if(selected[0] ==0 && selected[1] > 5 && selected[2] == 0 && selected[3] == 0 && selected[4] == 0)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[6];
            }
            // �����C�R��ȏ�Ȃ� ���̂U
            else if (selected[5] >= 3)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[5];
            }
            // �v�����Q��ȏ�Ȃ� ���̂R
            else if (selected[4] >= 2)
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[2];
            }
            // ����ȊO�Ȃ� ���̂S
            else
            {
                last.GetComponent<SpriteRenderer>().sprite = last_form[3];
            }

            // �Y�[�����ĕ\��
            last.transform.localScale = new Vector2(0.0f, 0.0f);
            last.GetComponent<Renderer>().sortingOrder = 6;
            for (float scale = 0.0f; scale <= 1.1f; scale += 0.1f)
            {
                last.transform.localScale = new Vector2(scale, scale);
                yield return new WaitForSeconds(0.1f);
            }
        }

        // �}�ӂƂ������{�^���̕\��
        button_Z.SetActive(true);
        button_R.SetActive(true);
    }
}
