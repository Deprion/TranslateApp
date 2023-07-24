using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Popup : MonoBehaviour, IPointerExitHandler
{
    [SerializeField] private GameObject popupItem;

    public void AddItem(string name, UnityAction action)
    { 
        var obj = Instantiate(popupItem, transform, false);
        obj.GetComponent<PopupItem>().Init(name, action);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Destroy(gameObject);
    }
}
