using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform _playerHand;
    [SerializeField] GameObject _cardPrefab;
    [SerializeField] int _initialResponseCard = 3;

    // Start is called before the first frame update
    void Start()
    {
        //手札を１枚配って、手札の子オブジェクトに加える
        for (var i = 0; i < _initialResponseCard; i++)
        {
            Instantiate(_cardPrefab, _playerHand);
        }

    }
}
