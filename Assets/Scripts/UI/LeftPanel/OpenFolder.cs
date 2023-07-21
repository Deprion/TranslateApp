using UnityEngine;
using UnityEngine.EventSystems;

public class OpenFolder : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject explorer;
    [SerializeField] private Transform parent;

    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(explorer, parent, false);
    }
}
