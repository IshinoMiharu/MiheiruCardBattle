using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// リーダーの立ち絵を変更するスクリプト
/// </summary>
public class LeaderSprite : MonoBehaviour
{
    [SerializeField] Sprite[] _leaderSprites;
    [SerializeField] Image _playerLeader;
    [SerializeField] Image _enemyLeader;
    int _playerIndex = 0; //キャラ選択ができるようになったらstatic変数をつくる
    int _enemyIndex = 1;

    // Start is called before the first frame update
    void Start()
    {
        _playerLeader.sprite = _leaderSprites[_playerIndex];
        _enemyLeader.sprite = _leaderSprites[_enemyIndex];
    }
}
