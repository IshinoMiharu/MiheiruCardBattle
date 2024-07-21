using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform _playerHand;
    [SerializeField] GameObject _cardPrefab;
    [SerializeField] int _initialResponseCard = 3;

    // Start is called before the first frame update
    void Start()
    {
        //��D���P���z���āA��D�̎q�I�u�W�F�N�g�ɉ�����
        for (var i = 0; i < _initialResponseCard; i++)
        {
            Instantiate(_cardPrefab, _playerHand);
        }

    }
}
