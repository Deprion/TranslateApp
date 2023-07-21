using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemList : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text text;

    public void Init(string name)
    {
        var arr = name.Split('\\');
        text.text = arr[arr.Length - 1];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
        else
        {
            Events.OpenFile.Invoke(text.text);
        }
    }
}
