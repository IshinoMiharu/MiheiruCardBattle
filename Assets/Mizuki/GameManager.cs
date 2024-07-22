using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform _playerHand;
    [SerializeField] GameObject _cardPrefab;
    [SerializeField] int _initialResponseCard = 3;
    bool _isPlayerTurn;

    // Start is called before the first frame update
    void Start()
    { 
        StartPhase();
    }

    /// <summary>
    /// スタートフェイズ
    /// </summary>
    void StartPhase()
    {
        SetStartHand();
        TurnDecision(); //ターンを決定するメソッド
    }

    void SetStartHand() //手札を配る、手札の子オブジェクトに加える
    {
        for (var i = 0; i < _initialResponseCard; i++)
        {
            DrowCard();
        }
    }

    void TurnDecision() //ターンを決定する
    {
        int rand = Random.Range(0, 2);
        if(rand == 0) _isPlayerTurn = true;
        TurnCalc();
    }

    /// <summary>
    /// メインフェイズ以降
    /// </summary>
    
    void TurnCalc() //ターンを管理する
    {
        if (_isPlayerTurn) PlayerTurn();
        else EnemyTurn();
    }
    
    void DrowCard() //カードを引く
    {
        //if (deck.Count == 0) return; デッキが0なら引かない
        Instantiate(_cardPrefab, _playerHand);
    }

    void PlayerTurn()
    {
        Debug.Log("Playerのターン");
        DrowCard();
    }

    void EnemyTurn()
    {
        Debug.Log("Enemyのターン");
        ChangeTurn();
    }

    public void ChangeTurn() //ターンエンドボタンにつける
    {
        _isPlayerTurn = !_isPlayerTurn;
        TurnCalc();
    }
}
