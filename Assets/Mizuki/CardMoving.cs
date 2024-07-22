using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMoving : MonoBehaviour, IDragHandler, IPointerDownHandler, IBeginDragHandler, IPointerUpHandler
{
    GameObject _filed; //
    RectTransform _rectTransform;
    /// <summary>�������O�ɏ������Ă����f�b�L</summary>
    Transform _originDeck = default;

    // Start is called before the first frame update
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _filed = GameObject.FindGameObjectWithTag("TableTag");
    }

    //�e�q�֌W�̈�Ԍ��ɂ���
    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        _rectTransform.position = eventData.position;
        transform.SetAsLastSibling();
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        string message = $"OnPointerDown: {this.name}: ";
        var currentDeck = GetCurrentDeck(eventData);

        if (currentDeck)
        {
            message += $"�}�E�X�|�C���^�� {currentDeck.name} �̏�ɂ���܂�";
            _originDeck = currentDeck.transform;
        }
        else
        {
            message += "�}�E�X�|�C���^�̓f�b�L�̏�ɂ���܂���";
        }

        Debug.Log(message);
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        var currentDeck = GetCurrentDeck(eventData);

        if (currentDeck)
        {
            if (currentDeck.name == "PlayerField")
            {
                transform.parent = currentDeck.transform;
            }
        }
        else if (currentDeck == null)
        {
            transform.parent = _originDeck;
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log($"OnBeginDrag: {name}");
        transform.SetParent(_filed.transform);
    }

    /// <summary>
    /// �}�E�X�J�[�\�������݂ǂ̃f�b�L�̏�ɂ��邩��Ԃ��B�f�b�L�Ƃ� "DeckTag" ���^�O�t�����ꂽ GameObject �̂��ƁB
    /// �Ȃ��A�f�b�L�� UI �I�u�W�F�N�g�܂� Rect Transform �R���|�[�l���g���A�^�b�`���ꂽ�I�u�W�F�N�g�ł���K�v������B
    /// </summary>
    /// <param name="eventData">PointerEventData �^�̈����B�}�E�X����̏�񂪓����Ă���B</param>
    /// <returns></returns>
    GameObject GetCurrentDeck(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results); // �}�E�X�|�C���^�̈ʒu��ɏd�Ȃ��Ă��� UI ��S�� results �Ɏ擾����i���j

        // results �ɓ����Ă���I�u�W�F�N�g�̂����ADeckTag ���t���Ă���I�u�W�F�N�g����� result �Ɏ擾����
        RaycastResult result = default;

        foreach (var item in results)
        {
            if (item.gameObject.CompareTag("DeckTag"))
            {
                result = item;
                break;
            }
        }

        return result.gameObject;   // ���ʂ� GameObject ��Ԃ�

        //�i���jEventSystem �̃C���^�[�t�F�C�X���g�����ʏ�̃v���O���~���O���ƁA�I�u�W�F�N�g���d�Ȃ��Ă���ꍇ�́u��ԏ�ɕ`�悳��Ă���I�u�W�F�N�g�v�����}�E�X�̓��������o�ł��Ȃ��B
        // ���̂��߁A�f�b�L�̏�ɃJ�[�h���d�Ȃ��Ă���ꍇ�A�f�b�L���Ń}�E�X�̓��������o�ł��Ȃ��B���̂��� EventSystem.current.RaycastAll ���g���K�v���������B
        // ���Ȃ݂� Hierarchy ��ŉ��ɂ��� UI �I�u�W�F�N�g���O�ʂɕ`�悳���B
    }


}
