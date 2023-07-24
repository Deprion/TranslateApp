using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PopupItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text txt;
    private UnityAction act;

    public void Init(string name, UnityAction action)
    {
        txt.text = name;
        act = action;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        act.Invoke();

        Destroy(transform.parent.gameObject);
    }
}
