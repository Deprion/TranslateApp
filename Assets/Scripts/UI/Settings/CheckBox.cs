using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CheckBox : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private Image image;
    private bool value;
    public SimpleEvent<bool> CheckBoxEvent = new SimpleEvent<bool>();

    public void Setup(bool val)
    {
        value = val;

        image.enabled = value;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        value = !value;

        image.enabled = value;

        CheckBoxEvent.Invoke(value);
    }
}
