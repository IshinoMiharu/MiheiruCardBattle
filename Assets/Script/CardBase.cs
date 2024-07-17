using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.Xml.Linq;



public class CardBase : MonoBehaviour, IDragHandler, IPointerUpHandler//, IPointerDownHandler
{
    // Start is called before the first frame update
    [Header("キャラ名")]
    [SerializeField] string cardName;
    [Header("カード効果")]
    [SerializeField] string cardText;
    [Header("まめちしき")]
    [SerializeField] string cardInt;
    [Header("召喚コスト")]
    [Range(0, 20)]
    [SerializeField] int cost;
    [Header("系統")]
    [SerializeField] int type;
    [Header("サブ系統")]
    [SerializeField] int subtipe;
    [Range(0, 20)]
    [Header("攻撃力")]
    [SerializeField] int Attack;
    [Range(0, 20)]
    [Header("攻撃力の増減値")]
    [SerializeField] int Attackplus;
    [Range(0, 20)]
    [Header("体力")]
    [SerializeField] int MaxHP;
    [Range(0, 20)]
    [Header("現在の体力")]
    [SerializeField] int HP;
    [Header("カードの固有識別番号")]
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

            // カードのリストに追加などの処理
        }
    }



    void Start()
    {
        CardText = new string[3];
        CardPoint = new int[8];
        CardText[0] = cardName;
        CardText[1] = cardText;//"このカードが場に出たとき、山札の一番上のカードを表向きにする。そのカードがゼリーマ系ならば、手札に加えてもよい。";
        CardText[2] = cardInt; //"プルプルした生命体。スライムと間違われるとキレるらしい。";
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


    //０、コスト
    //１、レアリティ
    //２、系統
    //３、サブ系統
    //４、攻撃力
    //５、増加攻撃力
    //６、最大体力
    //７、現在体力
    //８、カード番号

    //カードTextにて宣言
    //０、カード名
    //１、豆知識テキスト
    //２、効果

    public void OnClickCurd()
    {
         var Title = GameObject.Find("Title");
        CardTitle = Title.GetComponent<Text>();
        var Curd = GameObject.Find("CurdText");
        text = Curd.GetComponent<Text>();         
        Debug.Log("Curdtouch");
        CardTitle.text = CardText[0];
        text.text = "コスト：" + CardPoint[0] + "\n攻撃力：" + (CardPoint[3]+CardPoint[4]) + "\n体力　：" + CardPoint[5] + "\n効果　：" + CardText[1] + "\n豆知識：" + CardText[2];
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
        Debug.Log(eventData + "に落とす");

    }

   

}
