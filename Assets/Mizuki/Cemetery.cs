using UnityEngine;

/// <summary>
/// 墓地のボタンを押したら、墓地を表示するスクリプトです
/// </summary>
public class Cemetery : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    // Start is called before the first frame update
    void Start()
    {
        _panel.SetActive(false);
    }

    public void PanelActive()
    {
        _panel.SetActive(true);
    }

    public void PanelInactive() 
    {
        _panel.SetActive(false);
    }
}
