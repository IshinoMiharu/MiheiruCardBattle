using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CardBase : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Text text = default;
    [SerializeField] Text CardTitle = default;
    RectTransform _rectTransform = default;
    string[] CardText;
    int[] CardPoint;

    enum monster
    {
        Zerima,
        Tue,
        Wed,
        Thu,
        Fri,
        Sat,
        Sun
    };

    void Start()
    {

        CardText = new string[3];
        CardPoint = new int[8];
        CardText[0] = "�[���[�}";
        CardText[1] = "���̃J�[�h����ɏo���Ƃ��A�R�D�̈�ԏ�̃J�[�h��\�����ɂ���B���̃J�[�h���[���[�}�n�Ȃ�΁A��D�ɉ����Ă��悢�B";
        CardText[2] = "�v���v�����������́B�X���C���ƊԈ����ƃL����炵���B";
        CardPoint[0] = 1;
        CardPoint[1] = 1;
        CardPoint[2] = 1;
        CardPoint[3] = 1;
        CardPoint[4] = 1;
        CardPoint[5] = 1;
        CardPoint[6] = 1;
        CardPoint[7] = 1;
        _rectTransform = GetComponent<RectTransform>();
    }


    //�O�A�R�X�g
    //�P�A���A���e�B
    //�Q�A�n��
    //�R�A�T�u�n��
    //�S�A�U����
    //�T�A�����U����
    //�U�A�ő�̗�
    //�V�A���ݑ̗�
    //�W�A�J�[�h�ԍ�

    //�J�[�hText�ɂĐ錾
    //�O�A�J�[�h��
    //�P�A���m���e�L�X�g
    //�Q�A����

    public void OnClickCurd()
    {
        Debug.Log("Curdtouch");
        CardTitle.text = CardText[0];
        text.text = "�R�X�g�F" + CardPoint[0] + "\n�U���́F" + CardPoint[4] + "\n�̗́@�F" + CardPoint[6] + "\n���ʁ@�F" + CardText[1] + "\n���m���F" + CardText[2];

    }
}
