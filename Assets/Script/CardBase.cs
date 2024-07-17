using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Xml.Linq;



public class CardBase : MonoBehaviour, IDragHandler, IPointerUpHandler//, IPointerDownHandler
{
    // Start is called before the first frame update
    [Header("�L������")]
    [SerializeField] string cardName;
    [Header("�J�[�h����")]
    [SerializeField] string cardText;
    [Header("�܂߂�����")]
    [SerializeField] string cardInt;
    [Header("�����R�X�g")]
    [Range(0, 20)]
    [SerializeField] int cost;
    [Header("�n��")]
    [SerializeField] int type;
    [Header("�T�u�n��")]
    [SerializeField] int subtipe;
    [Range(0, 20)]
    [Header("�U����")]
    [SerializeField] int Attack;
    [Range(0, 20)]
    [Header("�U���͂̑����l")]
    [SerializeField] int Attackplus;
    [Range(0, 20)]
    [Header("�̗�")]
    [SerializeField] int MaxHP;
    [Range(0, 20)]
    [Header("���݂̗̑�")]
    [SerializeField] int HP;
    [Header("�J�[�h�̌ŗL���ʔԍ�")]
    [Range(0, 100)]
    [SerializeField] int Cardnumber;

    Text CardTitle = default;
    Text text = default;
     
    RectTransform _rectTransform = default;
    string[] CardText;
    int[] CardPoint;
    private List<Card> cards = new List<Card>();
    Transform _originDeck = default;
    public static GameObject selectedObject;

    

    public enum Monster
    {
        Zerima,
        Yusya,
        Sheru,
        Kris,
        Misyubis,
        Axe,
    }
    public class Card
    {
        public string Name { get; set; }
        public Monster Type { get; set; }
        public int Value { get; set; }

        public Card(string name, Monster type, int value)
        {
            Name = name;
            Type = type;
            Value = value;
        }
    }
    public class CardGame
    {
        public void CreateCards()
        {
            Card attackCard = new Card("Sword", Monster.Zerima, 10);
            Card defenseCard = new Card("Shield", Monster.Yusya, 5);
            Card healCard = new Card("Potion", Monster.Sheru, 8);
            Card specialCard = new Card("Magic", Monster.Misyubis, 12);

            // �J�[�h�̃��X�g�ɒǉ��Ȃǂ̏���
        }
    }



    void Start()
    {
        CardText = new string[3];
        CardPoint = new int[8];
        CardText[0] = cardName;
        CardText[1] = cardText;//"���̃J�[�h����ɏo���Ƃ��A�R�D�̈�ԏ�̃J�[�h��\�����ɂ���B���̃J�[�h���[���[�}�n�Ȃ�΁A��D�ɉ����Ă��悢�B";
        CardText[2] = cardInt; //"�v���v�����������́B�X���C���ƊԈ����ƃL����炵���B";
        CardPoint[0] = cost;
        CardPoint[1] = type;
        CardPoint[2] = subtipe;
        CardPoint[3] = Attack;
        CardPoint[4] = Attackplus;
        CardPoint[5] = MaxHP;
        CardPoint[6] =  HP;
        CardPoint[7] = Cardnumber;
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
         var Title = GameObject.Find("Title");
        CardTitle = Title.GetComponent<Text>();
        var Curd = GameObject.Find("CurdText");
        text = Curd.GetComponent<Text>();         
        Debug.Log("Curdtouch");
        CardTitle.text = CardText[0];
        text.text = "�R�X�g�F" + CardPoint[0] + "\n�U���́F" + (CardPoint[3]+CardPoint[4]) + "\n�̗́@�F" + CardPoint[5] + "\n���ʁ@�F" + CardText[1] + "\n���m���F" + CardText[2];
        selectedObject = this.gameObject;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log(eventData);
        _rectTransform.position = eventData.position;
        this.transform.SetAsLastSibling();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(eventData + "�ɗ��Ƃ�");

    }

   

}
