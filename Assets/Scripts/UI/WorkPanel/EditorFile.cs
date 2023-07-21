using TMPro;
using UnityEngine;

public class EditorFile : MonoBehaviour
{
    [SerializeField] private TMP_Text labelTxt;
    [SerializeField] private TMP_InputField contentTxt;

    public void Init(string label, string content)
    {
        labelTxt.text = label;
        contentTxt.text = content;
    }
}
