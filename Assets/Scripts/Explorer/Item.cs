using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text text;
    private string fullName;
    private Explorer exp;

    public void Init(Explorer exp, string name)
    {
        this.exp = exp;
        fullName = name;
        var arr = name.Split('\\');
        text.text = arr[arr.Length - 1];
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        exp.ChangeDir(fullName);
    }
}
