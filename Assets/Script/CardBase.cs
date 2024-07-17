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
        CardText[0] = "ゼリーマ";
        CardText[1] = "このカードが場に出たとき、山札の一番上のカードを表向きにする。そのカードがゼリーマ系ならば、手札に加えてもよい。";
        CardText[2] = "プルプルした生命体。スライムと間違われるとキレるらしい。";
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
        Debug.Log("Curdtouch");
        CardTitle.text = CardText[0];
        text.text = "コスト：" + CardPoint[0] + "\n攻撃力：" + CardPoint[4] + "\n体力　：" + CardPoint[6] + "\n効果　：" + CardText[1] + "\n豆知識：" + CardText[2];

    }
}
