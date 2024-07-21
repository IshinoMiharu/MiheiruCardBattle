using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 背景を変更するスクリプト
/// 現在はランダムで変更するようになっています
/// </summary>
public class BackgroundChange : MonoBehaviour
{
    Image _background;
    int _index;
    [SerializeField] Sprite[] _sprites;
    // Start is called before the first frame update
    void Start()
    {
        _background = GetComponent<Image>();
        int rand = Random.Range(0, _sprites.Length);
        _background.sprite = _sprites[rand];
    }
}
