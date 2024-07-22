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
    /// �X�^�[�g�t�F�C�Y
    /// </summary>
    void StartPhase()
    {
        SetStartHand();
        TurnDecision(); //�^�[�������肷�郁�\�b�h
    }

    void SetStartHand() //��D��z��A��D�̎q�I�u�W�F�N�g�ɉ�����
    {
        for (var i = 0; i < _initialResponseCard; i++)
        {
            DrowCard();
        }
    }

    void TurnDecision() //�^�[�������肷��
    {
        int rand = Random.Range(0, 2);
        if(rand == 0) _isPlayerTurn = true;
        TurnCalc();
    }

    /// <summary>
    /// ���C���t�F�C�Y�ȍ~
    /// </summary>
    
    void TurnCalc() //�^�[�����Ǘ�����
    {
        if (_isPlayerTurn) PlayerTurn();
        else EnemyTurn();
    }
    
    void DrowCard() //�J�[�h������
    {
        //if (deck.Count == 0) return; �f�b�L��0�Ȃ�����Ȃ�
        Instantiate(_cardPrefab, _playerHand);
    }

    void PlayerTurn()
    {
        Debug.Log("Player�̃^�[��");
        DrowCard();
    }

    void EnemyTurn()
    {
        Debug.Log("Enemy�̃^�[��");
        ChangeTurn();
    }

    public void ChangeTurn() //�^�[���G���h�{�^���ɂ���
    {
        _isPlayerTurn = !_isPlayerTurn;
        TurnCalc();
    }
}
