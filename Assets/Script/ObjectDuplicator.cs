using UnityEditor.SearchService;
using UnityEngine;

public class ObjectDuplicator : MonoBehaviour
{
    public Transform GamePanel;
    [SerializeField] RectTransform _rectTransform;
    public void DuplicateSelectedObject()
    {
        if (CardBase.selectedObject != null)
        {
            GameObject selectedObject = CardBase.selectedObject;
            //_rectTransform = selectedObject.GetComponent<RectTransform>();
            GameObject duplicatedObject=Instantiate(selectedObject, _rectTransform);
            duplicatedObject.transform.SetParent(GamePanel);
        }
    }
}